namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questionfixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuestionDBs", "Option3", c => c.String());
            AlterColumn("dbo.QuestionDBs", "Option4", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuestionDBs", "Option4", c => c.String(nullable: false));
            AlterColumn("dbo.QuestionDBs", "Option3", c => c.String(nullable: false));
        }
    }
}
