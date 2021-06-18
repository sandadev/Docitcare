using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class SlotBookingRepository: Repository<SlotBooking>,ISlotBookingRepository
    {
        public SlotBookingRepository(DocitcareDbContext context) : base(context)
        {

        }
    }
}