namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleting_BranchId_in_Department : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Departments", "BranchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "BranchId", c => c.Int(nullable: false));
        }
    }
}
