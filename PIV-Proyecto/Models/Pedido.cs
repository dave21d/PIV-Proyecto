using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIV_Proyecto.EntidadBases;

namespace PIV_Proyecto.Models
{
    public class Pedido:EntidadBase
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public decimal DescuentoTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }    


    }
}