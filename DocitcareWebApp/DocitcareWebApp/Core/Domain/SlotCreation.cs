using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocitcareWebApp.Core.Domain
{
    public class SlotCreation
    {
        [Required]
        [Display(Name = "Slot Id")]
        [Key]
        public int SlotId { get; set; }

        [Required]
        [Display(Name ="Slot Date")]
        public DateTime SlotDate { get; set; }

        [Required]
        [Display(Name ="Start Time")]
        public TimeSpan StartTime { get; set; }
       
        [Required]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }

        public int Duration { get; set; }

        [Display(Name ="Available")]
        public bool Available { get; set; }

        [Display(Name ="User Type")]
        public int UserType { get; set; }

        [Required]
        public int UserId { get; set; }
        [Display(Name = "Doctor")]
        public UserDetails UserDetails { get; set; }

        //[Required]
        //[Display(Name = "Department Name")]
        //public int DepartmentId { get; set; }
        //public Department Department { get; set; }

        [Required]
        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public bool Leave { get; set; }

        public bool Block { get; set; }

        [NotMapped]
        public string[] PrefferedDays { get; set; }
      
        public string StartDate { get; set; }
       
        public string EndDate { get; set; }

        public TimeSpan SlotTime { get; set; }
        public int StaffId { get; set; }
    }
}