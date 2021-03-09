using DocitcareWebApp.Core.Repositories;
using System;



namespace DocitcareWebApp.Core
{
    public interface IUnitOfWork: IDisposable
    {

        IRoleRepository Roles { get; }
        int Complete();
    }
}