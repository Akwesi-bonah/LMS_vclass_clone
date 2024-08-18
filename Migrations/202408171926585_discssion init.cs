namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discssioninit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscussionPostDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DiscussionTopicId = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiscussionTopicDBs", t => t.DiscussionTopicId, cascadeDelete: true)
                .ForeignKey("dbo.StudentDBs", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.DiscussionTopicId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.DiscussionTopicDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 255),
                        CourseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseDBs", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiscussionPostDBs", "StudentId", "dbo.StudentDBs");
            DropForeignKey("dbo.DiscussionPostDBs", "DiscussionTopicId", "dbo.DiscussionTopicDBs");
            DropForeignKey("dbo.DiscussionTopicDBs", "CourseId", "dbo.CourseDBs");
            DropIndex("dbo.DiscussionTopicDBs", new[] { "CourseId" });
            DropIndex("dbo.DiscussionPostDBs", new[] { "StudentId" });
            DropIndex("dbo.DiscussionPostDBs", new[] { "DiscussionTopicId" });
            DropTable("dbo.DiscussionTopicDBs");
            DropTable("dbo.DiscussionPostDBs");
        }
    }
}
