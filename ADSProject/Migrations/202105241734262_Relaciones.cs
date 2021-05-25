namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relaciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estudiante", "IdCarrera", c => c.Int(nullable: false));
            AddColumn("dbo.Materia", "IdCarrera", c => c.Int(nullable: false));
            CreateIndex("dbo.Estudiante", "IdCarrera");
            CreateIndex("dbo.Grupo", "IdCarrera");
            CreateIndex("dbo.Grupo", "IdMateria");
            CreateIndex("dbo.Grupo", "IdProfesor");
            CreateIndex("dbo.Materia", "IdCarrera");
            AddForeignKey("dbo.Estudiante", "IdCarrera", "dbo.Carrera", "id", cascadeDelete: true);
            AddForeignKey("dbo.Grupo", "IdCarrera", "dbo.Carrera", "id", cascadeDelete: true);
            AddForeignKey("dbo.Materia", "IdCarrera", "dbo.Carrera", "id", cascadeDelete: true);
            AddForeignKey("dbo.Grupo", "IdMateria", "dbo.Materia", "id", cascadeDelete: false);
            AddForeignKey("dbo.Grupo", "IdProfesor", "dbo.Profesor", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grupo", "IdProfesor", "dbo.Profesor");
            DropForeignKey("dbo.Grupo", "IdMateria", "dbo.Materia");
            DropForeignKey("dbo.Materia", "IdCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Grupo", "IdCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Estudiante", "IdCarrera", "dbo.Carrera");
            DropIndex("dbo.Materia", new[] { "IdCarrera" });
            DropIndex("dbo.Grupo", new[] { "IdProfesor" });
            DropIndex("dbo.Grupo", new[] { "IdMateria" });
            DropIndex("dbo.Grupo", new[] { "IdCarrera" });
            DropIndex("dbo.Estudiante", new[] { "IdCarrera" });
            DropColumn("dbo.Materia", "IdCarrera");
            DropColumn("dbo.Estudiante", "IdCarrera");
        }
    }
}
