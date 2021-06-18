namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upadted_Columns_SlotTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SlotCreations", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.SlotCreations", "Leave", c => c.Boolean(nullable: false));
            AddColumn("dbo.SlotCreations", "Block", c => c.Boolean(nullable: false));
            DropColumn("dbo.SlotCreations", "IsBooked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SlotCreations", "IsBooked", c => c.Boolean(nullable: false));
            DropColumn("dbo.SlotCreations", "Block");
            DropColumn("dbo.SlotCreations", "Leave");
            DropColumn("dbo.SlotCreations", "Available");
        }
    }
}
