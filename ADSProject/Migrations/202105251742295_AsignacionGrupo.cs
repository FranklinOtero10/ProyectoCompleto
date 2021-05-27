namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AsignacionGrupo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionGrupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdGrupo = c.Int(nullable: false),
                        IdEstudiante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estudiante", t => t.IdEstudiante, cascadeDelete: true)
                .ForeignKey("dbo.Grupo", t => t.IdGrupo, cascadeDelete: false)
                .Index(t => t.IdGrupo)
                .Index(t => t.IdEstudiante);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionGrupo", "IdGrupo", "dbo.Grupo");
            DropForeignKey("dbo.AsignacionGrupo", "IdEstudiante", "dbo.Estudiante");
            DropIndex("dbo.AsignacionGrupo", new[] { "IdEstudiante" });
            DropIndex("dbo.AsignacionGrupo", new[] { "IdGrupo" });
            DropTable("dbo.AsignacionGrupo");
        }
    }
}
