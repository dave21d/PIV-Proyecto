namespace PIV_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        ClasificacionId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        PorcentajeDescuento = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Clasificacion", t => t.ClasificacionId)
                .Index(t => t.ClasificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "ClasificacionId", "dbo.Clasificacion");
            DropIndex("dbo.Cliente", new[] { "ClasificacionId" });
            DropTable("dbo.Cliente");
        }
    }
}
