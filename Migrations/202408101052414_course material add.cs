namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursematerialadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseMaterialFileDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FilePath = c.String(nullable: false),
                        FileName = c.String(nullable: false),
                        MaterialId = c.Guid(nullable: false),
                        UploadedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseMaterialDBs", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.MaterialId);
            
            AddColumn("dbo.CourseMaterialDBs", "Content", c => c.String());
            DropColumn("dbo.CourseMaterialDBs", "FilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseMaterialDBs", "FilePath", c => c.String(nullable: false));
            DropForeignKey("dbo.CourseMaterialFileDBs", "MaterialId", "dbo.CourseMaterialDBs");
            DropIndex("dbo.CourseMaterialFileDBs", new[] { "MaterialId" });
            DropColumn("dbo.CourseMaterialDBs", "Content");
            DropTable("dbo.CourseMaterialFileDBs");
        }
    }
}
