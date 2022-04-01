using PIV_Proyecto.BaseDatos;
using PIV_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIV_Proyecto.Controllers
{
    public class UnidadMedidaController : Controller
    {
        private TiendaProductosContext context;

        public UnidadMedidaController()
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
            var tunidad = context.unidads.ToList();
            return View(tunidad);
        }

        public ActionResult Nuevo()
        {
            var tunidad = new Unidad();
            return View("UnidadMedidaForms",tunidad);
        }
        public ActionResult Editar(int id)
        {
            var unidadindb = context.unidads.SingleOrDefault(u => u.UnidadMedidaId == id);
            if (unidadindb == null)
                return HttpNotFound();

            return View("UnidadMedidaForms", unidadindb);
        }

        public ActionResult Detalles(int id)
        {
            var unidadindb = context.unidads.SingleOrDefault(u => u.UnidadMedidaId == id);
            if (unidadindb == null)
                return HttpNotFound();

            return View( unidadindb);
        }

        public ActionResult Eliminar(int id)
        {
            var unidadindb = context.unidads.SingleOrDefault(u => u.UnidadMedidaId == id);
            if (unidadindb == null)
                return HttpNotFound();

            return View(unidadindb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult CeEliminar(int id)
        {
            var unidadindb = context.unidads.SingleOrDefault(u => u.UnidadMedidaId == id);
            if (unidadindb == null)
                return HttpNotFound();

            context.unidads.Remove(unidadindb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Guardar(Unidad unidad)
        {
            if(!ModelState.IsValid)
                return View("UnidadMedidaForms", unidad);

            if (unidad.UnidadMedidaId == 0)
            {
                context.unidads.Add(unidad);
            }
            else
            {
                var unidadindb = context.unidads.SingleOrDefault(u => u.UnidadMedidaId == unidad.UnidadMedidaId);
                unidadindb.Codigo = unidad.Codigo;
                unidadindb.Descripcion = unidad.Descripcion;
                unidadindb.Estado = unidad.Estado;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}