using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class UserBranchRepository: Repository<UserBranches>, IUserBranchRepository
    {
        public UserBranchRepository(DocitcareDbContext context) : base(context)
        {

        }
        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }

        public IEnumerable<UserBranches> GetBranchCount(int userId)
        {
            return DocitcareDbContext.UserBranches.Where(x => x.UserId == userId).ToList();
        }
    }
}