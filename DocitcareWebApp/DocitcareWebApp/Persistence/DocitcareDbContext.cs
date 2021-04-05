using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using DocitcareWebApp.Core.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DocitcareWebApp.Persistence
{
    public partial class DocitcareDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<SuperAdminBranches> SuperAdminBranches { get; set; }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<AP_TS_Cities> AP_TS_Cities { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentBranches> DepartmentBranches { get; set; }

        public DbSet<SuperAdminRegistration> SuperAdminRegistrations { get; set; }



        public DocitcareDbContext()
            : base("name=DocitcareDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
