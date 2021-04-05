using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class DepartmentBranchesRepository : Repository<DepartmentBranches>, IDepartmentBranchRepository
    {
        public DepartmentBranchesRepository(DocitcareDbContext context):base(context)
        {

        }
        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }

        public IEnumerable<DepartmentBranches> GetBranchCount(int departmentId)
        {
            return DocitcareDbContext.DepartmentBranches.Where(x => x.DepartmentId == departmentId).ToList();
        }

        //public void RemoveBranches(int DepartmentId)
        //{
        //    var branches = DocitcareDbContext.DepartmentBranches.Where(x => x.DepartmentId == DepartmentId);
        //    DocitcareDbContext.DepartmentBranches.RemoveRange(branches);
        //}
    }
}