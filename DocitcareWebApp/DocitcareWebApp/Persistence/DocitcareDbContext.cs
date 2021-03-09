using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Persistence
{
    public partial class DocitcareDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DocitcareDbContext()
            : base("name=DocitcareDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
