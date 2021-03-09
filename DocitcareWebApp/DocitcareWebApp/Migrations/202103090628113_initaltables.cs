namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initaltables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Status_StatusID = c.Int(),
                    })
                .PrimaryKey(t => t.RoleID)
                .ForeignKey("dbo.Status", t => t.Status_StatusID)
                .Index(t => t.Status_StatusID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.StatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "Status_StatusID", "dbo.Status");
            DropIndex("dbo.Roles", new[] { "Status_StatusID" });
            DropTable("dbo.Status");
            DropTable("dbo.Roles");
        }
    }
}
