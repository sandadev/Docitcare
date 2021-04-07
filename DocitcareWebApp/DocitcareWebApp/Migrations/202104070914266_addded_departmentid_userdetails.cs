namespace DocitcareWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addded_departmentid_userdetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "DepartmentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "DepartmentId");
        }
    }
}
