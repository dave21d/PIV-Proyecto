using PIV_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.ViewModel
{
    public class FormsPedidoViewModel
    {
        public Pedido Pedido { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}