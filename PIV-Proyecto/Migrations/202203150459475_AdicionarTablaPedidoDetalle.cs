namespace PIV_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarTablaPedidoDetalle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PedidoDetalle",
                c => new
                    {
                        PedidoDetalleid = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalLinea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PedidoDetalleid)
                .ForeignKey("dbo.Pedido", t => t.Id)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => t.Id)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.PedidoDetalle", "Id", "dbo.Pedido");
            DropIndex("dbo.PedidoDetalle", new[] { "ProductoId" });
            DropIndex("dbo.PedidoDetalle", new[] { "Id" });
            DropTable("dbo.PedidoDetalle");
        }
    }
}
