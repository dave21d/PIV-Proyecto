using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [StringLength(10)]
        [Required]
        public string Codigo { get; set; }

        [StringLength(50)]
        [Required]
        public string Descripcion { get; set; }

        public int ClasificacionProductoId { get; set; }
        public ClasificacionProducto clasificacionProducto { get; set; }

        public int UnidadMedidaId { get; set; }
        public Unidad unidad { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public bool Estado { get; set; }
    }
}