using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.Domain
{
    public class Branch
    {
        [Required]
        [Display(Name = "Branch Id")]
        public int BranchId { get; set; }

        [Required]
        [Display(Name ="Branch Name")]
        public string BranchName { get; set; }


        public AP_TS_Cities City { get; set; }
        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }
        public Status Status { get; set; }
        public int StatusID { get; set; }
        [DataType(DataType.Upload)]
        public string FilePath { get; set; }

        public Entity Entity { get; set; }

        public int EntityId { get; set; }



    }
}