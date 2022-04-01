using System;
using PIV_Proyecto.BaseDatos;
using PIV_Proyecto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var productot = context.productos.Include(t => t.).ToList();
            return View(clientet);
           
        }
    }
}