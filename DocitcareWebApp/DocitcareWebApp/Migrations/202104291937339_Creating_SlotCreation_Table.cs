namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creating_SlotCreation_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SlotCreations",
                c => new
                    {
                        SlotId = c.Int(nullable: false, identity: true),
                        SlotDate = c.DateTime(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Duration = c.Int(nullable: false),
                        IsBooked = c.Boolean(nullable: false),
                        UserType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SlotId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: false)
                .ForeignKey("dbo.UserDetails", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SlotCreations", "UserId", "dbo.UserDetails");
            DropForeignKey("dbo.SlotCreations", "BranchId", "dbo.Branches");
            DropIndex("dbo.SlotCreations", new[] { "BranchId" });
            DropIndex("dbo.SlotCreations", new[] { "UserId" });
            DropTable("dbo.SlotCreations");
        }
    }
}
