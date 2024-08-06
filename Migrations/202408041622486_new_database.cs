namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 255),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDBs", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 255),
                        Role = c.String(nullable: false, maxLength: 20),
                        Status = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseAssignmentDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        FacilitatorId = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseDBs", t => t.CourseId)
                .ForeignKey("dbo.FacilitatorDBs", t => t.FacilitatorId)
                .Index(t => t.CourseId)
                .Index(t => t.FacilitatorId);
            
            CreateTable(
                "dbo.CourseDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 255),
                        Level = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FacilitatorDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 255),
                        UserId = c.Guid(nullable: false),
                        DepartmentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepartmentDBs", t => t.DepartmentId)
                .ForeignKey("dbo.UserDBs", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.DepartmentDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        DepartmentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepartmentDBs", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.StudentDBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        StudentNumber = c.String(nullable: false, maxLength: 20),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        Level = c.String(maxLength: 4),
                        UserId = c.Guid(nullable: false),
                        GroupId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupDBs", t => t.GroupId)
                .ForeignKey("dbo.UserDBs", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDBs", "UserId", "dbo.UserDBs");
            DropForeignKey("dbo.StudentDBs", "GroupId", "dbo.GroupDBs");
            DropForeignKey("dbo.GroupDBs", "DepartmentId", "dbo.DepartmentDBs");
            DropForeignKey("dbo.CourseAssignmentDBs", "FacilitatorId", "dbo.FacilitatorDBs");
            DropForeignKey("dbo.FacilitatorDBs", "UserId", "dbo.UserDBs");
            DropForeignKey("dbo.FacilitatorDBs", "DepartmentId", "dbo.DepartmentDBs");
            DropForeignKey("dbo.CourseAssignmentDBs", "CourseId", "dbo.CourseDBs");
            DropForeignKey("dbo.AdminDBs", "UserId", "dbo.UserDBs");
            DropIndex("dbo.StudentDBs", new[] { "GroupId" });
            DropIndex("dbo.StudentDBs", new[] { "UserId" });
            DropIndex("dbo.GroupDBs", new[] { "DepartmentId" });
            DropIndex("dbo.FacilitatorDBs", new[] { "DepartmentId" });
            DropIndex("dbo.FacilitatorDBs", new[] { "UserId" });
            DropIndex("dbo.CourseAssignmentDBs", new[] { "FacilitatorId" });
            DropIndex("dbo.CourseAssignmentDBs", new[] { "CourseId" });
            DropIndex("dbo.AdminDBs", new[] { "UserId" });
            DropTable("dbo.StudentDBs");
            DropTable("dbo.GroupDBs");
            DropTable("dbo.DepartmentDBs");
            DropTable("dbo.FacilitatorDBs");
            DropTable("dbo.CourseDBs");
            DropTable("dbo.CourseAssignmentDBs");
            DropTable("dbo.UserDBs");
            DropTable("dbo.AdminDBs");
        }
    }
}
