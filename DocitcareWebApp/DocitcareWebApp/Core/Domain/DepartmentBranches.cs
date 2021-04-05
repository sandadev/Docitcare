using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.Domain
{
    public class DepartmentBranches
    {
        [Key]
        public int DepartmentBranchesId { get; set; }
       
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        
    }
}