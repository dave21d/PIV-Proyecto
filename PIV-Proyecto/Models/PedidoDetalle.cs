using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.Models
{
    public class PedidoDetalle
    {
       [Key]
        public int PedidoDetalleid { get; set; }
        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public decimal Precio { get; set; } 
        public int Cantidad { get; set; }   
        public decimal Descuento { get; set; }  
        public decimal SubTotalLinea { get; set; }  
        public decimal Total { get; set; }  

    }
}