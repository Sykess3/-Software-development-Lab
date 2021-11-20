using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> EmployeesData { get; set; }
        public DbSet<AuthorizationInfo> AuthorizationInfos { get; set; }

        public EmployeeContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}