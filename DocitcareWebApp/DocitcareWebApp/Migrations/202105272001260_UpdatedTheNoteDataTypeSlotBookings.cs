namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTheNoteDataTypeSlotBookings : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SlotBookings", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SlotBookings", "Note", c => c.Boolean(nullable: false));
        }
    }
}
