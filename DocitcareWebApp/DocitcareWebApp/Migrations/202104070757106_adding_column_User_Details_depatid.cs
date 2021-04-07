namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_column_User_Details_depatid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "DepartmentId", c => c.Int(nullable: true));
            CreateIndex("dbo.UserDetails", "DepartmentId");
            AddForeignKey("dbo.UserDetails", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDetails", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.UserDetails", new[] { "DepartmentId" });
            DropColumn("dbo.UserDetails", "DepartmentId");
        }
    }
}
