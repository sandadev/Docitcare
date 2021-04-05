using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Core.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> GetWithStatusBranch();
        IEnumerable<DepartmentBranches> GetDepartmentBranchCount();
    }
}