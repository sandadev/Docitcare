namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddataannotaions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "BranchName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Branches", "BranchName", c => c.String());
        }
    }
}
