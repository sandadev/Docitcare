﻿using System;
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
            Department = new DepartmentRepository(_context);
            DepartmentBranches = new DepartmentBranchesRepository(_context);
            SuperAdminRegistration = new SuperAdminRegistraionRepository(_context);
            User = new UserRepository(_context);
            UserBranches = new UserBranchRepository(_context);
            Category = new CategoryRepository(_context);
            SlotCreation = new SlotCreationRepository(_context);
            SlotBooking= new SlotBookingRepository(_context);

        }
        public IRoleRepository Roles { get; private set; }
        public IEntityRepository Entities { get; private set; }
        public IAPTSCitiesRepository APTSCities { get; private set; }
        public IBranchRepository Branch { get; private set; }
        public IStatusRepository Status { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public IDepartmentBranchRepository DepartmentBranches { get; private set; }
        public ISuperAdminRegistrationRepository SuperAdminRegistration { get; private set; }
        public IUserRepository User { get; private set; }
        public IUserBranchRepository UserBranches { get; private set; }
         public ICategoryRepository Category { get; private set; }
        public ISlotCreationRepository SlotCreation { get; private set; }
        public ISlotBookingRepository SlotBooking { get; private set; }
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