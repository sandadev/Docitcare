using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.Domain
{
    public class Department
    {
        [Required]
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        
        [Display(Name = "Branches")]
        public IEnumerable<Branch> Branches { get; set; }

        [Display(Name = "Status")]
        public int StatusID { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Required Partner Details")]
        public int RequiredPartnerDetails { get; set; }
      
        [DataType(DataType.Upload)]
        [Display(Name = "File Upload")]
        public string File { get; set; }

        public Entity Entity { get; set; }

        public int EntityId { get; set; }


        [NotMapped]
        public int DepartmentCount { get; set; }

        [NotMapped]
        public string[] SelectedBrachesArray { get; set; }

    }
}