namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model_update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        FacilitatorDB_Id = c.Guid(),
                        GroupDB_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FacilitatorDBs", t => t.FacilitatorDB_Id)
                .ForeignKey("dbo.GroupDBs", t => t.GroupDB_Id)
                .Index(t => t.FacilitatorDB_Id)
                .Index(t => t.GroupDB_Id);
            
            CreateTable(
                "dbo.GroupDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        StudentDB_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentDBs", t => t.StudentDB_Id)
                .Index(t => t.StudentDB_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupDBs", "StudentDB_Id", "dbo.StudentDBs");
            DropForeignKey("dbo.DepartmentDBs", "GroupDB_Id", "dbo.GroupDBs");
            DropForeignKey("dbo.DepartmentDBs", "FacilitatorDB_Id", "dbo.FacilitatorDBs");
            DropIndex("dbo.GroupDBs", new[] { "StudentDB_Id" });
            DropIndex("dbo.DepartmentDBs", new[] { "GroupDB_Id" });
            DropIndex("dbo.DepartmentDBs", new[] { "FacilitatorDB_Id" });
            DropTable("dbo.GroupDBs");
            DropTable("dbo.DepartmentDBs");
        }
    }
}
