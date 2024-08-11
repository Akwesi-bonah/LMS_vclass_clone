namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Assignmentsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignmentSubmissionDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AssignmentId = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        Content = c.String(),
                        SubmissionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssignmentDBs", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.StudentDBs", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.AssignmentId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignmentSubmissionDBs", "StudentId", "dbo.StudentDBs");
            DropForeignKey("dbo.AssignmentSubmissionDBs", "AssignmentId", "dbo.AssignmentDBs");
            DropIndex("dbo.AssignmentSubmissionDBs", new[] { "StudentId" });
            DropIndex("dbo.AssignmentSubmissionDBs", new[] { "AssignmentId" });
            DropTable("dbo.AssignmentSubmissionDBs");
        }
    }
}
