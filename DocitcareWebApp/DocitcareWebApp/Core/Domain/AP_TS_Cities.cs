using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Core.Domain
{
    public class AP_TS_Cities
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        
    }
}