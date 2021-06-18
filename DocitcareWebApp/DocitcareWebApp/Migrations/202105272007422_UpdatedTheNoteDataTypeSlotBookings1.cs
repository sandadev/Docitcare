namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTheNoteDataTypeSlotBookings1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SlotBookings", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SlotBookings", "Note");
        }
    }
}
