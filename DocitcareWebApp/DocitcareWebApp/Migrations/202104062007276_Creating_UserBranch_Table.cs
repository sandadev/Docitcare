namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creating_UserBranch_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBranches",
                c => new
                    {
                        UserBranchesId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserBranchesId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBranches", "UserId", "dbo.Users");
            DropIndex("dbo.UserBranches", new[] { "UserId" });
            DropTable("dbo.UserBranches");
        }
    }
}
