using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.ViewModels
{
    public class DoctorSlotViewModel
    {
        public int UserId { get; set; }
        public string DoctorName { get; set; }
        public decimal Fee { get; set; }
        public string DepartmentName { get; set; }
        public DateTime SlotDate { get; set; }
        public string SlotStartTime { get; set; }
        public string SlotEndTime { get; set; }
        public TimeSpan SlotTime { get; set; }

    }
}