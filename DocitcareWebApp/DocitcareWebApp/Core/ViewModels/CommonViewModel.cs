using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Core.ViewModels
{
    public class CommonViewModel
    {
        public List<Branch> GetBranches { get; set; }
        public Department UserDepartment { get; set; }

        public IEnumerable<object> LoggedUserBranch { get; set; }

        public IEnumerable<Department> TotalDepartment { get; set; }
        public IEnumerable<SlotCreation> SlotCreations { get; set; }

        public UserDetails UserDetails { get; set; }

        public IEnumerable<UserDetails> UserList { get; set; }


    }

    
}