using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;
using DocitcareWebApp.Core.ViewModels;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class UserRepository: Repository<UserDetails>, IUserRepository
    {
        public UserRepository(DocitcareDbContext context) : base(context)
        {

        }

        const int DoctorRole = 7;
        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }

        public UserDetails ValidateCredentails(UserDetails model)
        {
            return DocitcareDbContext.Users.SingleOrDefault(x => x.TelephoneNumber1 == model.TelephoneNumber1 && x.Password == model.Password);
        }

        public IEnumerable<UserDetails> DoctorList(int entityId)
        {
            return DocitcareDbContext.Users.Where(x => x.EntityId == entityId && x.RoleID==DoctorRole).ToList();
        }

        public IEnumerable<UserDetails> DepartmentDoctor(int departmentId)
        {
           
          return DocitcareDbContext.Users.Where(x => x.DepartmentId == departmentId).ToList();
           
        }

        public IEnumerable<UserDetails> GetUserDetails(string Prefix,int roleId)
        {
            try
            {
                var convertInput = Convert.ToInt64(Prefix);
                return DocitcareDbContext.Users.Where(x => x.UserId == convertInput && x.RoleID==roleId || x.TelephoneNumber1 == convertInput && x.RoleID == roleId).ToList();
            }
            catch (Exception ex)
            {

                return DocitcareDbContext.Users.Where(x => x.FirstName.Contains(Prefix) && x.RoleID == roleId).ToList();
            }
           
        }

        public IEnumerable<DoctorSlotViewModel> DoctorSlotDetails(int userId)
        {
            DateTime baseDate = DateTime.Today;
            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

            var doctorSlotDetails = (from d in DocitcareDbContext.Users
                                     join sc in DocitcareDbContext.SlotCreations on d.UserId equals sc.UserId
                                     join dp in DocitcareDbContext.Departments on d.DepartmentId equals dp.DepartmentId
                                     where d.UserId == userId && sc.SlotDate >= thisWeekStart && sc.SlotDate <= thisWeekEnd
                                     select new DoctorSlotViewModel
                                     {
                                         UserId = d.UserId,
                                         DoctorName = d.FirstName + " " + d.LastName,
                                         Fee = d.ConsultationFee,
                                         DepartmentName = dp.DepartmentName,
                                         SlotDate = sc.SlotDate,
                                         SlotStartTime = sc.StartTime.ToString(),
                                         SlotEndTime = sc.EndTime.ToString(),
                                         SlotTime = sc.SlotTime

                                     }).ToList();

            return doctorSlotDetails;
        }
    }
}