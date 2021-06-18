namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRefferedbyColumnUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "ReferredBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "ReferredBy");
        }
    }
}
