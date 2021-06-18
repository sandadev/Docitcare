namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedAmountColumnsUserDetails : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserDetails", "ReferredBy");
            DropColumn("dbo.UserDetails", "AmountToPaid");
            DropColumn("dbo.UserDetails", "PaidAmount");
            DropColumn("dbo.UserDetails", "DueAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDetails", "DueAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.UserDetails", "PaidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.UserDetails", "AmountToPaid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.UserDetails", "ReferredBy", c => c.String());
        }
    }
}
