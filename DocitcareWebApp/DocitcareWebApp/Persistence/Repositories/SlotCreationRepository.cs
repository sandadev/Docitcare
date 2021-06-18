using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class SlotCreationRepository: Repository<SlotCreation>, ISlotCreationRepository
    {
        public SlotCreationRepository(DocitcareDbContext context) : base(context)
        {
        }
        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }

        public IEnumerable<SlotCreation> GetSlots(int userId,int appointmentType, DateTime selectedDate,int branchId)
        {
            return DocitcareDbContext.SlotCreations.Where(x => x.UserType == appointmentType && x.SlotDate == selectedDate && x.UserId==userId && x.BranchId==branchId).ToList();
        }
    }
}