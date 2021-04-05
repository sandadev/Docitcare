namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creating_SuperAdminRegistration_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuperAdminRegistrations",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MobileNumber = c.Int(nullable: false),
                        Email = c.Int(nullable: false),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SuperAdminRegistrations");
        }
    }
}
