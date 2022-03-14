using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.Models
{
    public class Unidad
    {
        [Key]
        public int UnidadMedidaId { get; set; }

        [StringLength(50)]
        [Required]
        public string Codigo { get; set; }

        [StringLength(50)]
        [Required]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}