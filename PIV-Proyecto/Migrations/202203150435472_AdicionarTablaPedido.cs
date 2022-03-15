namespace PIV_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarTablaPedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        DescuentoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Pedido", new[] { "ClienteId" });
            DropTable("dbo.Pedido");
        }
    }
}
