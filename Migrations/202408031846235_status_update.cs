namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDBs", "Status", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.AdminDBs", "Status");
            DropColumn("dbo.FacilitatorDBs", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FacilitatorDBs", "Status", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.AdminDBs", "Status", c => c.String());
            DropColumn("dbo.UserDBs", "Status");
        }
    }
}
