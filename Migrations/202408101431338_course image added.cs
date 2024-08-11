namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseimageadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseDBs", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseDBs", "ImagePath");
        }
    }
}
