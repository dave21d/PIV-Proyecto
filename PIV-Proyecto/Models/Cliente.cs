using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [StringLength(50)]
        [Required]
        public string Nombres { get; set; }

        [StringLength(50)]
        [Required]
        public string Apellidos { get; set; }
        public int ClasificacionId { get; set; }
        public Clasificacion clasificacion { get; set; }

        public DateTime FechaCreacion { get; set; }
        public int PorcentajeDescuento { get; set; }
        public bool Estado { get; set; }


    }
}