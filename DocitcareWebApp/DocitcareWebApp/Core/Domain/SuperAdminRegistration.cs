using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.Domain
{
    public class SuperAdminRegistration
    {
        [Key]
        [Required]
        public int AdminId { get; set; }
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}