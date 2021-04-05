using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;
using System.Data.Entity;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DocitcareDbContext context) : base(context)
        {

        }
        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }
        public IEnumerable<Department> GetWithStatusBranch()
        {
            return DocitcareDbContext.Departments.Include(r => r.Status).ToList();
        }
        public IEnumerable<DepartmentBranches> GetDepartmentBranchCount()
        {
            return DocitcareDbContext.DepartmentBranches.Include(r => r.DepartmentId).ToList();
        }
    }
}