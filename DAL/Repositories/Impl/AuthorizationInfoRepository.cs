using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Impl
{
    public class AuthorizationInfoRepository : BaseRepository<AuthorizationInfo>, IAuthorizationInfoRepository
    {
        internal AuthorizationInfoRepository(EmployeeContext context) : base(context)
        {
        }
    }
}