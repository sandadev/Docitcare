namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creating_SuperAdminRegistration_Table1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SuperAdminRegistrations", "MobileNumber", c => c.String(nullable: false));
            AlterColumn("dbo.SuperAdminRegistrations", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.SuperAdminRegistrations", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SuperAdminRegistrations", "Password", c => c.Int(nullable: false));
            AlterColumn("dbo.SuperAdminRegistrations", "Email", c => c.Int(nullable: false));
            AlterColumn("dbo.SuperAdminRegistrations", "MobileNumber", c => c.Int(nullable: false));
        }
    }
}
