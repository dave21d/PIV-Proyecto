using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.EntidadBases
{
    public class EntidadBase
    {
        [Key]
        public int Id { get; set; } 
        public DateTime FechaCreacion { get; set; } 
    }
}