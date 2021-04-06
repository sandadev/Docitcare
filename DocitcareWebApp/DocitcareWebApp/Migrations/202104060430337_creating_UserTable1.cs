namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creating_UserTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Pincode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Pincode");
        }
    }
}
