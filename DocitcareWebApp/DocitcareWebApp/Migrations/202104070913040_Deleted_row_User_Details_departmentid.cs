namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deleted_row_User_Details_departmentid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserDetails", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.UserDetails", new[] { "DepartmentId" });
            DropColumn("dbo.UserDetails", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDetails", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserDetails", "DepartmentId");
            AddForeignKey("dbo.UserDetails", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
