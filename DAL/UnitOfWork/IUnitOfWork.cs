using System;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorizationInfoRepository AuthorizationInfos { get; }
        IEmployeeRepository Employees { get; }
        void Save();
    }
}