using PIV_Proyecto.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIV_Proyecto.Models;



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
        // GET: Clasificacion
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
            var Clasindb = context.clasificacion.SingleOrDefault(u => u.ClasificacionId == id);
            if (Clasindb == null)
                return HttpNotFound();

            return View("ClasificacionForms", Clasindb);
        }
        public ActionResult Detalles(int id)
        {
            var Clasindb = context.clasificacion.SingleOrDefault(u => u.ClasificacionId == id);
            if (Clasindb == null)
                return HttpNotFound();

            return View(Clasindb);
        }
        public ActionResult Eliminar(int id)
        {
            var Clasindb = context.clasificacion.SingleOrDefault(u => u.ClasificacionId == id);
            if (Clasindb == null)
                return HttpNotFound();

            return View(Clasindb);
        }
        [HttpPost, ActionName("Eliminar")]
        public ActionResult Eliminar1(int id)
        {
            var Clasindb = context.clasificacion.SingleOrDefault(u => u.ClasificacionId == id);
            if (Clasindb == null)
                return HttpNotFound();

            context.clasificacion.Remove(Clasindb);
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