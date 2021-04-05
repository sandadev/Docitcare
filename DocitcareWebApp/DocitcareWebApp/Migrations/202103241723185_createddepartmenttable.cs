namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createddepartmenttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        BranchId = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        RequiredPartnerDetails = c.Int(nullable: false),
                        FilePath = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .Index(t => t.EntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "EntityId", "dbo.Entities");
            DropIndex("dbo.Departments", new[] { "EntityId" });
            DropTable("dbo.Departments");
        }
    }
}
