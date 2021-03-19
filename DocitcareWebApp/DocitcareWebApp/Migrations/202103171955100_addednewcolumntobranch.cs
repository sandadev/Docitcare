namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewcolumntobranch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "Entity_EntityId", c => c.Int());
            CreateIndex("dbo.Branches", "Entity_EntityId");
            AddForeignKey("dbo.Branches", "Entity_EntityId", "dbo.Entities", "EntityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "Entity_EntityId", "dbo.Entities");
            DropIndex("dbo.Branches", new[] { "Entity_EntityId" });
            DropColumn("dbo.Branches", "Entity_EntityId");
        }
    }
}
