using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Core.ViewModels
{
    public class UserViewModel
    {
        public UserDetails UserDetails { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Branch> Branches { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public string[] SelectedBrachesArray { get; set; }
        public IEnumerable<UserBranches> BranchList { get; set; }

    }
}