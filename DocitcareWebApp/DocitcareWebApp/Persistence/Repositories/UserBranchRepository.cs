using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;
using System.Data.Entity;

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

        public IEnumerable<object> GetUserBranchesName(int userId)
        {
            var BranchNames = DocitcareDbContext.Branches
                .Join(DocitcareDbContext.UserBranches,
                      p => p.BranchId,
                      e => e.BranchId,

                      (p, e) => new
                      {
                          BranchId = p.BranchId,
                          BranchName = p.BranchName,
                          UserId = e.UserId
                      }).Where(x => x.UserId == userId).ToList();
            return BranchNames;
        }

      
    }
}