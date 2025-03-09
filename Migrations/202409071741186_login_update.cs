namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDBs", "lastLogin", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDBs", "lastLogin");
        }
    }
}
