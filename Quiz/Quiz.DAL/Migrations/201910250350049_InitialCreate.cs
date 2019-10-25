namespace Quiz.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IDPersona = c.Int(nullable: false),
                        Pais = c.String(),
                        Provincia = c.String(),
                        Canton = c.String(),
                        Distrito = c.String(),
                        Detalle = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.IDPersona })
                .ForeignKey("dbo.Datos_Persona", t => t.IDPersona, cascadeDelete: true)
                .Index(t => t.IDPersona);
            
            CreateTable(
                "dbo.Datos_Persona",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direccions", "IDPersona", "dbo.Datos_Persona");
            DropIndex("dbo.Direccions", new[] { "IDPersona" });
            DropTable("dbo.Datos_Persona");
            DropTable("dbo.Direccions");
        }
    }
}
