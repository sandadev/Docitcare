namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class created_Department_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        StatusID = c.Int(nullable: false),
                        RequiredPartnerDetails = c.Int(nullable: false),
                        File = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.StatusID)
                .Index(t => t.EntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Departments", "EntityId", "dbo.Entities");
            DropIndex("dbo.Departments", new[] { "EntityId" });
            DropIndex("dbo.Departments", new[] { "StatusID" });
            DropTable("dbo.Departments");
        }
    }
}
