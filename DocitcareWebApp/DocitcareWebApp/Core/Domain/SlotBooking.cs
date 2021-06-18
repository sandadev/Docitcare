using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocitcareWebApp.Core.Domain
{
    public class SlotBooking
    {
        [Key]
        [Display(Name ="Booking Id")]
        [Required]
        public int BookingId { get; set; }

        [Required]
        [Display(Name ="User Id")]
        public int UserId { get; set; }
        public UserDetails UserDetails { get; set; }

        [Required]
        [Display(Name = "Slot Id")]
        public int SlotId { get; set; }
        [Required]
        [Display(Name = "Staff Id")]
        public int StaffId { get; set; }

        [Display(Name ="Reffered By")]
        public string RefferedBy { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Paid Amount")]
        public decimal PaidAmount { get; set; }
        [Display(Name = "Due Amount")]
        public decimal DueAmount { get; set; }

        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }

        [Display(Name = "Follow Up")]
        public bool FollowUp { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }



    }
}