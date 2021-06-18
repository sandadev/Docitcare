namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredFromUserDetails1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.UserDetails", "State", c => c.String(nullable: false));
            AlterColumn("dbo.UserDetails", "City", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "City", c => c.String());
            AlterColumn("dbo.UserDetails", "State", c => c.String());
            AlterColumn("dbo.UserDetails", "Country", c => c.String());
        }
    }
}
