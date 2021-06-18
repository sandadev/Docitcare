namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedSlotBookingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SlotBookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SlotId = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                        RefferedBy = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.UserDetails", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SlotBookings", "UserId", "dbo.UserDetails");
            DropIndex("dbo.SlotBookings", new[] { "UserId" });
            DropTable("dbo.SlotBookings");
        }
    }
}
