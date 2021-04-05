namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolumnenityidinroletable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Entity_EntityId", c => c.Int());
            CreateIndex("dbo.Roles", "Entity_EntityId");
            AddForeignKey("dbo.Roles", "Entity_EntityId", "dbo.Entities", "EntityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "Entity_EntityId", "dbo.Entities");
            DropIndex("dbo.Roles", new[] { "Entity_EntityId" });
            DropColumn("dbo.Roles", "Entity_EntityId");
        }
    }
}
