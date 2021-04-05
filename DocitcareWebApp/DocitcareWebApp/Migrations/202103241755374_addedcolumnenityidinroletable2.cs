namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolumnenityidinroletable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "Entity_EntityId", "dbo.Entities");
            DropIndex("dbo.Roles", new[] { "Entity_EntityId" });
            RenameColumn(table: "dbo.Roles", name: "Entity_EntityId", newName: "EntityId");
            AlterColumn("dbo.Roles", "EntityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Roles", "EntityId");
            AddForeignKey("dbo.Roles", "EntityId", "dbo.Entities", "EntityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "EntityId", "dbo.Entities");
            DropIndex("dbo.Roles", new[] { "EntityId" });
            AlterColumn("dbo.Roles", "EntityId", c => c.Int());
            RenameColumn(table: "dbo.Roles", name: "EntityId", newName: "Entity_EntityId");
            CreateIndex("dbo.Roles", "Entity_EntityId");
            AddForeignKey("dbo.Roles", "Entity_EntityId", "dbo.Entities", "EntityId");
        }
    }
}
