namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseassigement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignmentDBs", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignmentDBs", "FileName");
        }
    }
}
