using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class SuperAdminRegistraionRepository: Repository<SuperAdminRegistration>, ISuperAdminRegistrationRepository
    {
        public SuperAdminRegistraionRepository(DocitcareDbContext context) : base(context)
        {

        }



        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }

        public SuperAdminRegistration ValidateCredentails(SuperAdminRegistration model)
        {
            //return DocitcareDbContext.SuperAdminRegistrations.Any(x => x.MobileNumber == model.MobileNumber && x.Password == model.Password);

            return DocitcareDbContext.SuperAdminRegistrations.SingleOrDefault(x => x.MobileNumber == model.MobileNumber && x.Password == model.Password);
        }

      
    }
}