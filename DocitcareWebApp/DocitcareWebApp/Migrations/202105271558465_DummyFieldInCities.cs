namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DummyFieldInCities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AP_TS_Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        FilePath = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.AP_TS_Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.StatusID)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        EntityId = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(nullable: false),
                        HoilderFirstName = c.String(nullable: false),
                        HolderLastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        HospitalContactNumber1 = c.String(nullable: false),
                        HospitalContactNumber2 = c.String(),
                        ContactPersonName = c.String(nullable: false),
                        ContactPhoneNumberName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        EstablishedYear = c.Int(nullable: false),
                        RegisteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId);
            
            CreateTable(
                "dbo.SuperAdminBranches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        EntityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.Entities", t => t.EntityID, cascadeDelete: true)
                .Index(t => t.EntityID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepartmentBranches",
                c => new
                    {
                        DepartmentBranchesId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentBranchesId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        StatusID = c.Int(nullable: false),
                        RequiredPartnerDetails = c.Int(nullable: false),
                        File = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.StatusID)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        StatusID = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.StatusID)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.SlotBookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SlotId = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                        RefferedBy = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookingDate = c.DateTime(nullable: false),
                        FollowUp = c.Boolean(nullable: false),
                        Note = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.UserDetails", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        TelephoneNumber1 = c.Long(nullable: false),
                        TelephoneNumber2 = c.Long(),
                        Gender = c.Int(nullable: false),
                        Email = c.String(),
                        MartialStatus = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Age = c.Byte(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        Country = c.String(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Pincode = c.String(),
                        Specialisation = c.String(),
                        Experience = c.String(),
                        Languages = c.String(),
                        Certification = c.String(),
                        AwardsRecognition = c.String(),
                        Membership = c.String(),
                        Registration = c.String(),
                        File = c.String(),
                        ConsultationFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserType = c.Int(nullable: false),
                        Password = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpadtedDate = c.DateTime(nullable: false),
                        RoleID = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.SlotCreations",
                c => new
                    {
                        SlotId = c.Int(nullable: false, identity: true),
                        SlotDate = c.DateTime(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Duration = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                        UserType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Leave = c.Boolean(nullable: false),
                        Block = c.Boolean(nullable: false),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        SlotTime = c.Time(nullable: false, precision: 7),
                        StaffId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SlotId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.UserDetails", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.SuperAdminRegistrations",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.UserBranches",
                c => new
                    {
                        UserBranchesId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserBranchesId)
                .ForeignKey("dbo.UserDetails", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBranches", "UserId", "dbo.UserDetails");
            DropForeignKey("dbo.SlotCreations", "UserId", "dbo.UserDetails");
            DropForeignKey("dbo.SlotCreations", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.SlotBookings", "UserId", "dbo.UserDetails");
            DropForeignKey("dbo.UserDetails", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserDetails", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Roles", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Roles", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.DepartmentBranches", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Departments", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Branches", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Branches", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.SuperAdminBranches", "EntityID", "dbo.Entities");
            DropForeignKey("dbo.Branches", "CityId", "dbo.AP_TS_Cities");
            DropIndex("dbo.UserBranches", new[] { "UserId" });
            DropIndex("dbo.SlotCreations", new[] { "BranchId" });
            DropIndex("dbo.SlotCreations", new[] { "UserId" });
            DropIndex("dbo.UserDetails", new[] { "EntityId" });
            DropIndex("dbo.UserDetails", new[] { "RoleID" });
            DropIndex("dbo.SlotBookings", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "EntityId" });
            DropIndex("dbo.Roles", new[] { "StatusID" });
            DropIndex("dbo.Departments", new[] { "EntityId" });
            DropIndex("dbo.Departments", new[] { "StatusID" });
            DropIndex("dbo.DepartmentBranches", new[] { "DepartmentId" });
            DropIndex("dbo.SuperAdminBranches", new[] { "EntityID" });
            DropIndex("dbo.Branches", new[] { "EntityId" });
            DropIndex("dbo.Branches", new[] { "StatusID" });
            DropIndex("dbo.Branches", new[] { "CityId" });
            DropTable("dbo.UserBranches");
            DropTable("dbo.SuperAdminRegistrations");
            DropTable("dbo.SlotCreations");
            DropTable("dbo.UserDetails");
            DropTable("dbo.SlotBookings");
            DropTable("dbo.Roles");
            DropTable("dbo.Departments");
            DropTable("dbo.DepartmentBranches");
            DropTable("dbo.Categories");
            DropTable("dbo.Status");
            DropTable("dbo.SuperAdminBranches");
            DropTable("dbo.Entities");
            DropTable("dbo.Branches");
            DropTable("dbo.AP_TS_Cities");
        }
    }
}
