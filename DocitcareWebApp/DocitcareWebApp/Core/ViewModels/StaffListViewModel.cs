using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;


namespace DocitcareWebApp.Core.ViewModels
{
    public class StaffListViewModel
    {
       
        [Display(Name ="User Id")]
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        public string Gender { get; set; }
   
        public string Role { get; set; }

        public string Branches { get; set; }


    }
}