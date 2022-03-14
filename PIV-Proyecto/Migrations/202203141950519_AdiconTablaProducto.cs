namespace PIV_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdiconTablaProducto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 10),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        ClasificacionProductoId = c.Int(nullable: false),
                        UnidadMedidaId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.ClasificacionProducto", t => t.ClasificacionProductoId)
                .ForeignKey("dbo.Unidad", t => t.UnidadMedidaId)
                .Index(t => t.ClasificacionProductoId)
                .Index(t => t.UnidadMedidaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "UnidadMedidaId", "dbo.Unidad");
            DropForeignKey("dbo.Producto", "ClasificacionProductoId", "dbo.ClasificacionProducto");
            DropIndex("dbo.Producto", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Producto", new[] { "ClasificacionProductoId" });
            DropTable("dbo.Producto");
        }
    }
}
