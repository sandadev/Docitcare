namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creating_UserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        TelephoneNumber1 = c.String(nullable: false),
                        TelephoneNumber2 = c.String(),
                        Gender = c.Int(nullable: false),
                        MartialStatus = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Age = c.Byte(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Specialisation = c.String(),
                        Experience = c.String(),
                        Languages = c.String(),
                        Certification = c.String(),
                        AwardsRecognition = c.String(),
                        Membership = c.String(),
                        File = c.String(),
                        ConsultationFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserType = c.Int(nullable: false),
                        Password = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpadtedDate = c.DateTime(nullable: false),
                        RoleID = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Categories", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: false)
                .Index(t => t.RoleID)
                .Index(t => t.DepartmentId)
                .Index(t => t.EntityId)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Users", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "Id", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "EntityId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropTable("dbo.Users");
        }
    }
}
