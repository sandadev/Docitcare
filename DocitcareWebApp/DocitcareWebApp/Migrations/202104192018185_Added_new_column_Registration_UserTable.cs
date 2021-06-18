namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_new_column_Registration_UserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "Registration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "Registration");
        }
    }
}
