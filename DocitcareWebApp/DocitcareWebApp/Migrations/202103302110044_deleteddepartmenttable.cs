namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteddepartmenttable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "EntityId", "dbo.Entities");
            DropIndex("dbo.Departments", new[] { "EntityId" });
            DropTable("dbo.Departments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        StatusID = c.Int(nullable: false),
                        RequiredPartnerDetails = c.Int(nullable: false),
                        FilePath = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateIndex("dbo.Departments", "EntityId");
            AddForeignKey("dbo.Departments", "EntityId", "dbo.Entities", "EntityId", cascadeDelete: true);
        }
    }
}
