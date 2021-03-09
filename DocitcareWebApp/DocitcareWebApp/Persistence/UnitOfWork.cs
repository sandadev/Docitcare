using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocitcareWebApp.Core;
using DocitcareWebApp.Core.Repositories;
using DocitcareWebApp.Persistence.Repositories;

namespace DocitcareWebApp.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DocitcareDbContext _context;
        public UnitOfWork(DocitcareDbContext context)
        {
            _context = context;
            Roles = new RoleRepository(_context);
        }
        public IRoleRepository Roles { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}