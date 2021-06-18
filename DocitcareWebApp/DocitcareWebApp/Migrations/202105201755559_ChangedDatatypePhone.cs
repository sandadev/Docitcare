namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDatatypePhone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "TelephoneNumber1", c => c.Long(nullable: false));
            AlterColumn("dbo.UserDetails", "TelephoneNumber2", c => c.Long(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "TelephoneNumber2", c => c.String());
            AlterColumn("dbo.UserDetails", "TelephoneNumber1", c => c.String(nullable: false));
        }
    }
}
