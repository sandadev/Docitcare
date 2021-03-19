using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Core.ViewModels
{
    public class BranchViewModel
    {
        public Branch Branch { get; set; }
        public IEnumerable<AP_TS_Cities> Cities { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
        

    }
}