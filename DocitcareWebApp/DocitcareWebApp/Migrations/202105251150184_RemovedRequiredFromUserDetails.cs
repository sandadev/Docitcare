namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredFromUserDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "Address2", c => c.String());
            AlterColumn("dbo.UserDetails", "Country", c => c.String());
            AlterColumn("dbo.UserDetails", "State", c => c.String());
            AlterColumn("dbo.UserDetails", "City", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "City", c => c.String(nullable: false));
            AlterColumn("dbo.UserDetails", "State", c => c.String(nullable: false));
            AlterColumn("dbo.UserDetails", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.UserDetails", "Address2", c => c.String(nullable: false));
        }
    }
}
