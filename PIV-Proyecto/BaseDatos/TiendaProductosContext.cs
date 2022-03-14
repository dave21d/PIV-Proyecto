using PIV_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PIV_Proyecto.BaseDatos
{
    public class TiendaProductosContext:DbContext
    {
        public TiendaProductosContext():base("TiendaProductos")
        {


        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();// se hace para no pluralizar los nobres de las tablas
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();// eliminacion escascada para lo que se borre sea todo lo que dependa de ella
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();// se elimina de uno a muchos
        }

        public DbSet<Clasificacion> clasificacion { get; set; }
        public DbSet<Unidad> unidads { get; set; }
        public DbSet<ClasificacionProducto> clasificacionProductos { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Cliente> clientes { get; set; }


    }
}