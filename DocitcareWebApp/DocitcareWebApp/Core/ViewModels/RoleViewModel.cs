using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Core.ViewModels
{
    public class RoleViewModel
    {
        public Role Role { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}