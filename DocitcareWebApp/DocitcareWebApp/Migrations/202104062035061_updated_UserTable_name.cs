namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated_UserTable_name : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "UserDetails");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserDetails", newName: "Users");
        }
    }
}
