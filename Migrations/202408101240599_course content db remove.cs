namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursecontentdbremove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseContentDBs", "CourseId", "dbo.CourseDBs");
            DropIndex("dbo.CourseContentDBs", new[] { "CourseId" });
            DropTable("dbo.CourseContentDBs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseContentDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CourseContentDBs", "CourseId");
            AddForeignKey("dbo.CourseContentDBs", "CourseId", "dbo.CourseDBs", "Id", cascadeDelete: true);
        }
    }
}
