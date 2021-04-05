using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Core.Repositories
{
    public interface IDepartmentBranchRepository: IRepository<DepartmentBranches>
    {
        IEnumerable<DepartmentBranches> GetBranchCount(int departmentId);
        //void RemoveBranches(int DepartmentId);
    }
}