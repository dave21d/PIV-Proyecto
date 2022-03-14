using PIV_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.ViewModel
{
    public class FormsProductoViewModel
    {
        public Producto producto { get; set; }

        public List<ClasificacionProducto> clasificacionProductos { get; set; }

        public List<Unidad> unidads { get; set; }
    }
}