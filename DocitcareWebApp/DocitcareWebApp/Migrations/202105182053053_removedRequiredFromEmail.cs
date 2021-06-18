namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedRequiredFromEmail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "Email", c => c.String());
            AlterColumn("dbo.UserDetails", "Pincode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "Pincode", c => c.String(nullable: false));
            AlterColumn("dbo.UserDetails", "Email", c => c.String(nullable: false));
        }
    }
}
