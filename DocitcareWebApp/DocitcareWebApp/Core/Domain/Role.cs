using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.Domain
{
    public class Role           
    {
     
        [Required]
        [Display(Name ="Role ID")]
        public int RoleID { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        [Display(Name = "Status")]
        public Status Status { get; set; }

        public int StatusID { get; set; }

        public Entity Entity { get; set; }

        public int EntityId { get; set; }
    }
}