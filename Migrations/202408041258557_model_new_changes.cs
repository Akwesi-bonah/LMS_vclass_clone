namespace vclass_clone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model_new_changes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DepartmentDBs", new[] { "FacilitatorDB_Id" });
            RenameColumn(table: "dbo.FacilitatorDBs", name: "FacilitatorDB_Id", newName: "Department_Id");
            CreateIndex("dbo.FacilitatorDBs", "Department_Id");
            DropColumn("dbo.DepartmentDBs", "FacilitatorDB_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DepartmentDBs", "FacilitatorDB_Id", c => c.Guid());
            DropIndex("dbo.FacilitatorDBs", new[] { "Department_Id" });
            RenameColumn(table: "dbo.FacilitatorDBs", name: "Department_Id", newName: "FacilitatorDB_Id");
            CreateIndex("dbo.DepartmentDBs", "FacilitatorDB_Id");
        }
    }
}
