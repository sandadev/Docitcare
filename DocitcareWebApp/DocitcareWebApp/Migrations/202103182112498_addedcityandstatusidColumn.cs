namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcityandstatusidColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "City_CityId", "dbo.AP_TS_Cities");
            DropForeignKey("dbo.Branches", "Status_StatusID", "dbo.Status");
            DropIndex("dbo.Branches", new[] { "City_CityId" });
            DropIndex("dbo.Branches", new[] { "Status_StatusID" });
            RenameColumn(table: "dbo.Branches", name: "City_CityId", newName: "CityId");
            RenameColumn(table: "dbo.Branches", name: "Status_StatusID", newName: "StatusID");
            AlterColumn("dbo.Branches", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Branches", "StatusID", c => c.Int(nullable: false));
            CreateIndex("dbo.Branches", "CityId");
            CreateIndex("dbo.Branches", "StatusID");
            AddForeignKey("dbo.Branches", "CityId", "dbo.AP_TS_Cities", "CityId", cascadeDelete: true);
            AddForeignKey("dbo.Branches", "StatusID", "dbo.Status", "StatusID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Branches", "CityId", "dbo.AP_TS_Cities");
            DropIndex("dbo.Branches", new[] { "StatusID" });
            DropIndex("dbo.Branches", new[] { "CityId" });
            AlterColumn("dbo.Branches", "StatusID", c => c.Int());
            AlterColumn("dbo.Branches", "CityId", c => c.Int());
            RenameColumn(table: "dbo.Branches", name: "StatusID", newName: "Status_StatusID");
            RenameColumn(table: "dbo.Branches", name: "CityId", newName: "City_CityId");
            CreateIndex("dbo.Branches", "Status_StatusID");
            CreateIndex("dbo.Branches", "City_CityId");
            AddForeignKey("dbo.Branches", "Status_StatusID", "dbo.Status", "StatusID");
            AddForeignKey("dbo.Branches", "City_CityId", "dbo.AP_TS_Cities", "CityId");
        }
    }
}
