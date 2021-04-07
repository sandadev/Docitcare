namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deleted_row_User_Details_CategoryId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserDetails", "Id", "dbo.Categories");
            DropIndex("dbo.UserDetails", new[] { "Id" });
            DropColumn("dbo.UserDetails", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDetails", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.UserDetails", "Id");
            AddForeignKey("dbo.UserDetails", "Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
