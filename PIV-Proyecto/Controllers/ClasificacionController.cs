using System;
using PIV_Proyecto.BaseDatos;
using PIV_Proyecto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIV_Proyecto.Controllers
{
    public class ClasificacionController : Controller
    {
        private TiendaProductosContext context;

        public ClasificacionController()
        {
            context = new TiendaProductosContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }
        public ActionResult Index()
        {
            var clasi = context.clasificacion.ToList();
            return View(clasi);
        }

        public ActionResult Nuevo()
        {
            var clasi = new Clasificacion();
            return View("ClasificacionForms", clasi);
        }

        public ActionResult Editar(int id)
        {
            var clasificacionindb = context.clasificacion.SingleOrDefault(u => u.ClasificacionId == id);
            if (clasificacionindb == null)
                return HttpNotFound();

            return View("ClasificacionForms", clasificacionindb);
        }

        public ActionResult Detalles(int id)
        {
            var clasificacionindb = context.clasificacion.SingleOrDefault(u => u.ClasificacionId == id);
            if (clasificacionindb == null)
                return HttpNotFound();

            return View(clasificacionindb);
        }

        public ActionResult Eliminar(int id)
        {
            var clasificacionindb = context.clasificacion.SingleOrDefault(u => u.ClasificacionId == id);
            if (clasificacionindb == null)
                return HttpNotFound();

            return View(clasificacionindb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult CeEliminar(int id)
        {
            var clasificacionindb = context.clasificacion.SingleOrDefault(u => u.ClasificacionId == id);
            if (clasificacionindb == null)
                return HttpNotFound();

            context.clasificacion.Remove(clasificacionindb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Guardar(Clasificacion clasificacion)
        {
            if (!ModelState.IsValid)
                return View("ClasificacionForms", clasificacion);

            if (clasificacion.ClasificacionId == 0)
            {
                context.clasificacion.Add(clasificacion);
            }
            else
            {
                var clasificacionindb = context.clasificacion.SingleOrDefault(u => u.ClasificacionId == clasificacion.ClasificacionId);
                clasificacionindb.Codigo = clasificacion.Codigo;
                clasificacionindb.Descripcion = clasificacion.Descripcion;
                clasificacionindb.Estado = clasificacion.Estado;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}