namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class created_DepartmentBranches_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentBranches",
                c => new
                    {
                        DepartmentBranchesId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentBranchesId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentBranches", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.DepartmentBranches", new[] { "DepartmentId" });
            DropTable("dbo.DepartmentBranches");
        }
    }
}
