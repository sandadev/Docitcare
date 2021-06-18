namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202105250114435_UpdatedTelephoneNumber2Rqeuired1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "TelephoneNumber2", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "TelephoneNumber2", c => c.Long(nullable: false));
        }
    }
}
