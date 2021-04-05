namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedstatusinroleandstatusclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "Status_StatusID", "dbo.Status");
            DropIndex("dbo.Roles", new[] { "Status_StatusID" });
            RenameColumn(table: "dbo.Roles", name: "Status_StatusID", newName: "StatusID");
            AlterColumn("dbo.Status", "StatusName", c => c.String(nullable: false));
            AlterColumn("dbo.Roles", "StatusID", c => c.Int(nullable: false));
            CreateIndex("dbo.Roles", "StatusID");
            AddForeignKey("dbo.Roles", "StatusID", "dbo.Status", "StatusID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "StatusID", "dbo.Status");
            DropIndex("dbo.Roles", new[] { "StatusID" });
            AlterColumn("dbo.Roles", "StatusID", c => c.Int());
            AlterColumn("dbo.Status", "StatusName", c => c.String());
            RenameColumn(table: "dbo.Roles", name: "StatusID", newName: "Status_StatusID");
            CreateIndex("dbo.Roles", "Status_StatusID");
            AddForeignKey("dbo.Roles", "Status_StatusID", "dbo.Status", "StatusID");
        }
    }
}
