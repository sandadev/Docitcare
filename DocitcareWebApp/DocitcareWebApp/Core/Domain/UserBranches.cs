using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocitcareWebApp.Core.Domain
{
    public class UserBranches
    {
        [Key]
        public int UserBranchesId { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }
        public UserDetails User { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }
    }
}