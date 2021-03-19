using DocitcareWebApp.Core.Domain;
using System.Collections.Generic;

namespace DocitcareWebApp.Core.Repositories
{
    public interface IRoleRepository: IRepository<Role>
    {
        IEnumerable<Role> GetRolesWithStatus();
    }
}