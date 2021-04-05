using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Core.ViewModels
{
    public class DepartmentViewModel
    {
        public Department Department { get; set; }
        public IEnumerable<Department> DepartmentList { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Branch> Branches { get; set; }

        public IEnumerable<DepartmentBranches> BranchList { get; set; }

        public string[] SelectedBrachesArray { get; set; }


    }
}