namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursemanagementupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignmentDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseDBs", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseContentDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseDBs", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseMaterialDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        FilePath = c.String(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        UploadedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseDBs", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseMaterialDBs", "CourseId", "dbo.CourseDBs");
            DropForeignKey("dbo.CourseContentDBs", "CourseId", "dbo.CourseDBs");
            DropForeignKey("dbo.AssignmentDBs", "CourseId", "dbo.CourseDBs");
            DropIndex("dbo.CourseMaterialDBs", new[] { "CourseId" });
            DropIndex("dbo.CourseContentDBs", new[] { "CourseId" });
            DropIndex("dbo.AssignmentDBs", new[] { "CourseId" });
            DropTable("dbo.CourseMaterialDBs");
            DropTable("dbo.CourseContentDBs");
            DropTable("dbo.AssignmentDBs");
        }
    }
}
