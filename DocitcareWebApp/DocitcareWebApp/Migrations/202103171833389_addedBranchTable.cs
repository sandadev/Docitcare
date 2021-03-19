namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBranchTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        FilePath = c.String(),
                        City_CityId = c.Int(),
                        Status_StatusID = c.Int(),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.AP_TS_Cities", t => t.City_CityId)
                .ForeignKey("dbo.Status", t => t.Status_StatusID)
                .Index(t => t.City_CityId)
                .Index(t => t.Status_StatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "Status_StatusID", "dbo.Status");
            DropForeignKey("dbo.Branches", "City_CityId", "dbo.AP_TS_Cities");
            DropIndex("dbo.Branches", new[] { "Status_StatusID" });
            DropIndex("dbo.Branches", new[] { "City_CityId" });
            DropTable("dbo.Branches");
        }
    }
}
