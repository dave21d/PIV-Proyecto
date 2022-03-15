using PIV_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.ViewModel
{
    public class FormsPedidoDetalleViewModel
    {
        public PedidoDetalle pedidoDetalle { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public List<Producto> Productos { get; set; }   
    }
}