namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSlotBookingFollowUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SlotBookings", "FollowUp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SlotBookings", "FollowUp");
        }
    }
}
