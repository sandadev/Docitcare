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
            Entities = new EntityRepository(_context);
            APTSCities = new APTSCitiesRepository(_context);
            Branch = new BranchRepository(_context);
            Status = new StatusRepository(_context);

        }
        public IRoleRepository Roles { get; private set; }
        public IEntityRepository Entities { get; private set; }
        public IAPTSCitiesRepository APTSCities { get; private set; }
        public IBranchRepository Branch { get; private set; }
        public IStatusRepository Status { get; private set; }
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