using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class EntityRepository : Repository<Entity>, IEntityRepository
    {
        public EntityRepository(DocitcareDbContext context) : base(context)
        {

        }

        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }
    }
}