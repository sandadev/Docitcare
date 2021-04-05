using DocitcareWebApp.Core.Repositories;
using System;



namespace DocitcareWebApp.Core
{
    public interface IUnitOfWork: IDisposable
    {

        IRoleRepository Roles { get; }
        IEntityRepository Entities { get; }
        IAPTSCitiesRepository APTSCities { get; }
        IBranchRepository Branch { get; }
        IStatusRepository Status { get; }

        IDepartmentRepository Department { get; }
        IDepartmentBranchRepository DepartmentBranches { get; }
        ISuperAdminRegistrationRepository SuperAdminRegistration { get; }
        int Complete();
    }
}