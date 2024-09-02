namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quizsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 60),
                        Description = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Duration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseDBs", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.QuestionDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QuizId = c.Guid(nullable: false),
                        QuestionText = c.String(nullable: false),
                        Option1 = c.String(nullable: false),
                        Option2 = c.String(nullable: false),
                        Option3 = c.String(nullable: false),
                        Option4 = c.String(nullable: false),
                        Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizDBs", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionDBs", "QuizId", "dbo.QuizDBs");
            DropForeignKey("dbo.QuizDBs", "CourseId", "dbo.CourseDBs");
            DropIndex("dbo.QuestionDBs", new[] { "QuizId" });
            DropIndex("dbo.QuizDBs", new[] { "CourseId" });
            DropTable("dbo.QuestionDBs");
            DropTable("dbo.QuizDBs");
        }
    }
}
