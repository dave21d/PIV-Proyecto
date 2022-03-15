namespace PIV_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarTablaPedidoForce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "Estado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido", "Estado");
        }
    }
}
