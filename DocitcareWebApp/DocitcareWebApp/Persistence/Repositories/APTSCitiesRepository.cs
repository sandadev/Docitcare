using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class APTSCitiesRepository: Repository<AP_TS_Cities>,IAPTSCitiesRepository
    {
        public APTSCitiesRepository(DocitcareDbContext context): base(context)
        {

        }
        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }
    }
}