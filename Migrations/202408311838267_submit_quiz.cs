namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class submit_quiz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizSubmissionDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QuizId = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        QuizDB_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizDBs", t => t.QuizId)
                .ForeignKey("dbo.StudentDBs", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.QuizDBs", t => t.QuizDB_Id)
                .Index(t => t.QuizId)
                .Index(t => t.StudentId)
                .Index(t => t.QuizDB_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizSubmissionDBs", "QuizDB_Id", "dbo.QuizDBs");
            DropForeignKey("dbo.QuizSubmissionDBs", "StudentId", "dbo.StudentDBs");
            DropForeignKey("dbo.QuizSubmissionDBs", "QuizId", "dbo.QuizDBs");
            DropIndex("dbo.QuizSubmissionDBs", new[] { "QuizDB_Id" });
            DropIndex("dbo.QuizSubmissionDBs", new[] { "StudentId" });
            DropIndex("dbo.QuizSubmissionDBs", new[] { "QuizId" });
            DropTable("dbo.QuizSubmissionDBs");
        }
    }
}
