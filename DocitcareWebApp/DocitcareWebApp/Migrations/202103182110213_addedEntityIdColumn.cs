namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEntityIdColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "Entity_EntityId", "dbo.Entities");
            DropIndex("dbo.Branches", new[] { "Entity_EntityId" });
            RenameColumn(table: "dbo.Branches", name: "Entity_EntityId", newName: "EntityId");
            AlterColumn("dbo.Branches", "EntityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Branches", "EntityId");
            AddForeignKey("dbo.Branches", "EntityId", "dbo.Entities", "EntityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "EntityId", "dbo.Entities");
            DropIndex("dbo.Branches", new[] { "EntityId" });
            AlterColumn("dbo.Branches", "EntityId", c => c.Int());
            RenameColumn(table: "dbo.Branches", name: "EntityId", newName: "Entity_EntityId");
            CreateIndex("dbo.Branches", "Entity_EntityId");
            AddForeignKey("dbo.Branches", "Entity_EntityId", "dbo.Entities", "EntityId");
        }
    }
}
