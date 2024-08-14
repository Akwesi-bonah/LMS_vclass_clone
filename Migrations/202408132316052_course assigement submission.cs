namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseassigementsubmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignmentSubmissionDBs", "IsSubmitted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignmentSubmissionDBs", "IsSubmitted");
        }
    }
}
