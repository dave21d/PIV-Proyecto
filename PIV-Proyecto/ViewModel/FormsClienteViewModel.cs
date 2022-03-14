using PIV_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.ViewModel
{
    public class FormsClienteViewModel
    {
        public Cliente cliente { get; set; }
        public List<Clasificacion> clasificacions { get; set; }
    }
}