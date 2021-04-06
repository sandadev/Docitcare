namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creating_CategoryTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Type");
        }
    }
}
