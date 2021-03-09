using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.Domain
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public Status Status { get; set; }
    }
}