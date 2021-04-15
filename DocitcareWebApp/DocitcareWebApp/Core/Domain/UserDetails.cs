using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Core.Domain
{
    public class UserDetails
    {
        [Key]
        [Required]
        [Display(Name ="User ID")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Telephone Number 1")]
        public string TelephoneNumber1 { get; set; }
       
        [Display(Name = "Telephone Number 2")]
        public string TelephoneNumber2 { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public int Gender { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Martial Status")]
        public int MartialStatus { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Age")]
        public byte Age { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }
        [Required]
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Pincode")]
        public string Pincode { get; set; }

        [Display(Name = "Select Branches")]
        public IEnumerable<Branch> Branches { get; set; }
        [Display(Name = "Specialisation")]
        public string Specialisation { get; set; }
        [Display(Name = "Experience")]
        public string Experience { get; set; }
        [Display(Name = "Languages")]
        public string Languages { get; set; }
        [Display(Name = "Certification")]
        public string Certification { get; set; }
        [Display(Name = "AwardsRecognition")]
        public string AwardsRecognition { get; set; }
        [Display(Name = "Membership")]
        public string Membership { get; set; }
        [Display(Name = "File Upload")]
        public string File { get; set; }
        [Required]
        [Display(Name = "Consultation Fee")]
        public decimal ConsultationFee { get; set; }
        [Display(Name = "User Type")]
        public int UserType { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpadtedDate { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int RoleID { get; set; }

        public Role Role { get; set; }

        [Required]
        public int EntityId { get; set; }

        public Entity Entity { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }

        [NotMapped]
        public string[] SelectedBrachesArray { get; set; }






    }
}