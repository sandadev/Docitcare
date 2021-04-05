using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.Domain
{
    public class Status
    {
        [Required]
        [Display(Name ="Status Id")]
        public int StatusID { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string StatusName { get; set; }
    }
}