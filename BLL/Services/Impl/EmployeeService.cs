using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using Employee = DAL.Entities.Employee;

namespace BLL.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
            if (_database == null)
                throw new ArgumentNullException(nameof(unitOfWork));
        }


        public EmployeeDTO GetEmployee(int id, int pageNumber)
        {
            AccessValidation();

            var employee = _database.Employees.Get(id);

            IEnumerable<Employee> employeesEntities =
                _database
                    .Employees.Find(x => x.Id == id, pageNumber, pageSize);

            if (employeesEntities.Count() > 1)
                throw new InvalidOperationException();

            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Employee, EmployeeDTO>())
                    .CreateMapper();

            var employeesDto =
                mapper
                    .Map<Employee, EmployeeDTO>(employeesEntities.First());

            return employeesDto;

        }

        private static void AccessValidation()
        {
            var userType = SecurityContext.User.GetType();
            if (userType != typeof(Manager)
                && userType != typeof(Admin))
                throw new MethodAccessException();
        }
    }
}