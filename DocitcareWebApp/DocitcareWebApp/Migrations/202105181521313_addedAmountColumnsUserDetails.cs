namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAmountColumnsUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "AmountToPaid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.UserDetails", "PaidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.UserDetails", "DueAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "DueAmount");
            DropColumn("dbo.UserDetails", "PaidAmount");
            DropColumn("dbo.UserDetails", "AmountToPaid");
        }
    }
}
