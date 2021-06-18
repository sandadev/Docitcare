namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DummyFieldInCitiesremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AP_TS_Cities", "CitySteetNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AP_TS_Cities", "CitySteetNo", c => c.Int(nullable: false));
        }
    }
}
