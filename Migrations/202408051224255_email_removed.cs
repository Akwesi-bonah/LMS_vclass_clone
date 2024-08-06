namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class email_removed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StudentDBs", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentDBs", "Email", c => c.String(nullable: false));
        }
    }
}
