namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAPTStable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AP_TS_Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AP_TS_Cities");
        }
    }
}
