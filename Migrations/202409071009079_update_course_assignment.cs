namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_course_assignment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseAssignmentDBs", "GroupId", c => c.Guid(nullable: false));
            AddColumn("dbo.CourseAssignmentDBs", "Groups_Id", c => c.Guid());
            CreateIndex("dbo.CourseAssignmentDBs", "Groups_Id");
            AddForeignKey("dbo.CourseAssignmentDBs", "Groups_Id", "dbo.GroupDBs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssignmentDBs", "Groups_Id", "dbo.GroupDBs");
            DropIndex("dbo.CourseAssignmentDBs", new[] { "Groups_Id" });
            DropColumn("dbo.CourseAssignmentDBs", "Groups_Id");
            DropColumn("dbo.CourseAssignmentDBs", "GroupId");
        }
    }
}
