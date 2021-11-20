using System;
using System.Runtime.InteropServices;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EmployeeContext _db;
        private IAuthorizationInfoRepository _authorizationInfos;
        private IEmployeeRepository _employees;


        public EFUnitOfWork(EmployeeContext context)
        {
            _db = context;
        }

        public IAuthorizationInfoRepository AuthorizationInfos
        {
            get
            {
                if (_authorizationInfos == null)
                    _authorizationInfos = new AuthorizationInfoRepository(_db);
                
                return _authorizationInfos;
            }
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (_employees == null) 
                    _employees = new EmployeeRepository(_db);

                return _employees;
            }
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _dissposed;

        public virtual void Dispose(bool dispossing)
        {
            if (_dissposed)
                return;
            
            if (dispossing) 
                _db.Dispose();

            _dissposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}