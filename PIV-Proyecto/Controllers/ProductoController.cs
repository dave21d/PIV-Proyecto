using System;
using PIV_Proyecto.BaseDatos;
using PIV_Proyecto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PIV_Proyecto.ViewModel;

namespace PIV_Proyecto.Controllers
{
    public class ProductoController : Controller
    {
        private TiendaProductosContext context;

        public ProductoController()
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
            var productot = context.productos.ToList();
            return View(productot);

        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            var producto = new Producto();
            producto.FechaCreacion = DateTime.Now;
            var clasificacionProducto = context.clasificacionProductos.Where(c => c.Estado == true).ToList();
            var unidadMedida = context.unidads.Where(c => c.Estado == true).ToList();
            var viewModel = new FormsProductoViewModel
            {
                producto = producto,
                clasificacionProductos = clasificacionProducto,
                unidads = unidadMedida
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Nuevo(Producto producto)
        {
            producto.FechaCreacion = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            context.productos.Add(producto);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detalles(int id)
        {
            var producto = context.productos.SingleOrDefault(c => c.ProductoId == id);
            if (producto == null)
                return HttpNotFound();

            return View(producto);
        }

        public ActionResult Editar(int id)
        {
            var producto = context.productos.SingleOrDefault(c => c.ProductoId == id);
            if (producto == null)
                return HttpNotFound();

            var clasificacionProducto = context.clasificacionProductos.Where(c => c.Estado == true).ToList();
            var unidadMedida = context.unidads.Where(c => c.Estado == true).ToList();
            var viewModel = new FormsProductoViewModel
            {
                producto = producto,
                clasificacionProductos = clasificacionProducto,
                unidads = unidadMedida
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            var productoInDb = context.productos.SingleOrDefault(p => p.ProductoId == producto.ProductoId);
            productoInDb.Codigo = producto.Codigo;
            productoInDb.Descripcion = producto.Descripcion;
            productoInDb.Precio = producto.Precio;
            productoInDb.Estado = producto.Estado;
            productoInDb.ClasificacionProductoId = producto.ClasificacionProductoId;
            productoInDb.UnidadMedidaId = producto.UnidadMedidaId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            var producto = context.productos.SingleOrDefault(c => c.ProductoId == id);
            if (producto == null)
                return HttpNotFound();

            return View(producto);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            var producto = context.productos.SingleOrDefault(c => c.ProductoId == id);
            if (producto == null)
                return HttpNotFound();

            context.productos.Remove(producto);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}