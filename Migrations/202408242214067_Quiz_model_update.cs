namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quiz_model_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizDBs", "MaxAttempts", c => c.Int(nullable: false));
            AddColumn("dbo.QuizDBs", "IsPublished", c => c.Boolean(nullable: false));
            AddColumn("dbo.QuizDBs", "PassingScore", c => c.Int(nullable: false));
            AddColumn("dbo.QuizDBs", "TotalMarks", c => c.Int(nullable: false));
            AlterColumn("dbo.QuizDBs", "Duration", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuizDBs", "Duration", c => c.DateTime(nullable: false));
            DropColumn("dbo.QuizDBs", "TotalMarks");
            DropColumn("dbo.QuizDBs", "PassingScore");
            DropColumn("dbo.QuizDBs", "IsPublished");
            DropColumn("dbo.QuizDBs", "MaxAttempts");
        }
    }
}
