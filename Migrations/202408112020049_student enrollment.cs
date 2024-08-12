namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentenrollment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseEnrollmentDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseDBs", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.StudentDBs", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseEnrollmentDBs", "StudentId", "dbo.StudentDBs");
            DropForeignKey("dbo.CourseEnrollmentDBs", "CourseId", "dbo.CourseDBs");
            DropIndex("dbo.CourseEnrollmentDBs", new[] { "StudentId" });
            DropIndex("dbo.CourseEnrollmentDBs", new[] { "CourseId" });
            DropTable("dbo.CourseEnrollmentDBs");
        }
    }
}
