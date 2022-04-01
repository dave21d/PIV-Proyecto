<<<<<<< HEAD
﻿using System;
using PIV_Proyecto.BaseDatos;
using PIV_Proyecto.Models;
=======
﻿using PIV_Proyecto.BaseDatos;
using System;
>>>>>>> 4b3e4ed6f180eb062c75d9d73d5347f3e73cb0e3
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
=======
using PIV_Proyecto.Models;


>>>>>>> 4b3e4ed6f180eb062c75d9d73d5347f3e73cb0e3

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
<<<<<<< HEAD
=======
        // GET: Clasificacion
>>>>>>> 4b3e4ed6f180eb062c75d9d73d5347f3e73cb0e3
        public ActionResult Index()
        {
            var clasi = context.clasificacion.ToList();
            return View(clasi);
<<<<<<< HEAD
        }

=======

        }
>>>>>>> 4b3e4ed6f180eb062c75d9d73d5347f3e73cb0e3
        public ActionResult Nuevo()
        {
            var clasi = new Clasificacion();
            return View("ClasificacionForms", clasi);
        }
<<<<<<< HEAD

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

=======
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


>>>>>>> 4b3e4ed6f180eb062c75d9d73d5347f3e73cb0e3
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
<<<<<<< HEAD
        }
=======
        

        
        }


>>>>>>> 4b3e4ed6f180eb062c75d9d73d5347f3e73cb0e3
    }
}