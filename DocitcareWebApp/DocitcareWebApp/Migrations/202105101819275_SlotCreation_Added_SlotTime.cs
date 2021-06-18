namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlotCreation_Added_SlotTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SlotCreations", "StartDate", c => c.String());
            AddColumn("dbo.SlotCreations", "EndDate", c => c.String());
            AddColumn("dbo.SlotCreations", "SlotTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.SlotCreations", "StaffId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SlotCreations", "StaffId");
            DropColumn("dbo.SlotCreations", "SlotTime");
            DropColumn("dbo.SlotCreations", "EndDate");
            DropColumn("dbo.SlotCreations", "StartDate");
        }
    }
}
