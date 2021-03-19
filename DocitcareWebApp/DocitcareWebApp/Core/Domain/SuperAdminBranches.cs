using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.Domain
{
    public class SuperAdminBranches
    {
     
        [Key]
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public Entity Entiy { get; set; }
        public int EntityID { get; set; }


    }
}