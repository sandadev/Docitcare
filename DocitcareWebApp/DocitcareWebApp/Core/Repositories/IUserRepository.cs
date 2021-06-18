using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.ViewModels;

namespace DocitcareWebApp.Core.Repositories
{
    public interface IUserRepository : IRepository<UserDetails>
    {
        UserDetails ValidateCredentails(UserDetails model);
        IEnumerable<UserDetails> DoctorList(int EntityId);
        IEnumerable<UserDetails> DepartmentDoctor(int departmentId);

        IEnumerable<UserDetails> GetUserDetails(string Prefix,int roleId);

        IEnumerable<DoctorSlotViewModel> DoctorSlotDetails(int userId);
    }
}