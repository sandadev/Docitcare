using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;
using System.Data.Entity;


namespace DocitcareWebApp.Persistence.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(DocitcareDbContext context) : base(context)
        {

        }
        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }
        public IEnumerable<Branch> GetBranchWithStatusCity()
        {
            return DocitcareDbContext.Branches.Include(r => r.Status).Include(c=>c.City).ToList();
        }
    }
}