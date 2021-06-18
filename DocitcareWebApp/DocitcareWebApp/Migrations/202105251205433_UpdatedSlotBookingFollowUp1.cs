namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSlotBookingFollowUp1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SlotBookings", "Note", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SlotBookings", "Note");
        }
    }
}
