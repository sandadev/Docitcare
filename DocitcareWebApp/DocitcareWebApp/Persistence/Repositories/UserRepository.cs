using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.Repositories;

namespace DocitcareWebApp.Persistence.Repositories
{
    public class UserRepository: Repository<UserDetails>, IUserRepository
    {
        public UserRepository(DocitcareDbContext context) : base(context)
        {

        }
        public DocitcareDbContext DocitcareDbContext
        {
            get { return Context as DocitcareDbContext; }
        }

        public UserDetails ValidateCredentails(UserDetails model)
        {
            return DocitcareDbContext.Users.SingleOrDefault(x => x.TelephoneNumber1 == model.TelephoneNumber1 && x.Password == model.Password);
        }
    }
}