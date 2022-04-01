using System;
using PIV_Proyecto.BaseDatos;
using PIV_Proyecto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIV_Proyecto.Controllers
{
    public class ClasificacionProductoController : Controller
    {
        private TiendaProductosContext context;

        public ClasificacionProductoController()
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
            var clasiproducto = context.clasificacionProductos.ToList();
            return View(clasiproducto);
        }

        public ActionResult Nuevo()
        {
            var clasiproducto = new ClasificacionProducto();
            return View("ClasificacionProductoForms", clasiproducto);
        }

        public ActionResult Editar(int id)
        {
            var clasiproducto = context.clasificacionProductos.SingleOrDefault(u => u.ClasificacionProductoId == id);
            if (clasiproducto == null)
                return HttpNotFound();

            return View("ClasificacionProductoForms", clasiproducto);
        }

        public ActionResult Detalles(int id)
        {
            var clasificacionproductoindb = context.clasificacionProductos.SingleOrDefault(u => u.ClasificacionProductoId == id);
            if (clasificacionproductoindb == null)
                return HttpNotFound();

            return View(clasificacionproductoindb);
        }

        public ActionResult Eliminar(int id)
        {
            var clasificacionproductoindb = context.clasificacionProductos.SingleOrDefault(u => u.ClasificacionProductoId == id);
            if (clasificacionproductoindb == null)
                return HttpNotFound();

            return View(clasificacionproductoindb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult CeEliminar(int id)
        {
            var clasificacionproductoindb = context.clasificacionProductos.SingleOrDefault(u => u.ClasificacionProductoId == id);
            if (clasificacionproductoindb == null)
                return HttpNotFound();

            context.clasificacionProductos.Remove(clasificacionproductoindb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Guardar(ClasificacionProducto clasificacionProducto)
        {
            if (!ModelState.IsValid)
                return View("ClasificacionProductoForms", clasificacionProducto);

            if (clasificacionProducto.ClasificacionProductoId == 0)
            {
                context.clasificacionProductos.Add(clasificacionProducto);
            }
            else
            {
                var clasificacionproductoindb = context.clasificacionProductos.SingleOrDefault(u => u.ClasificacionProductoId == clasificacionProducto.ClasificacionProductoId);
                clasificacionproductoindb.Codigo = clasificacionProducto.Codigo;
                clasificacionproductoindb.Descripcion = clasificacionProducto.Descripcion;
                clasificacionproductoindb.Estado = clasificacionProducto.Estado;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}