namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseEnrollmentadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseDBs", "EnrollmentKey", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseDBs", "EnrollmentKey");
        }
    }
}
