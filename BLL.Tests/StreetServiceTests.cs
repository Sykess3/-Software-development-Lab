using System;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Enums;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using Xunit;

namespace BLL.Tests
{
    public class StreetServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new EmployeeService(nullUnitOfWork)
            );
        }

        [Fact]
        public void GetEmployee_EmployeeIsDeveloper_ThrowsMethodAccessException()
        {
            // Arrange
            SecurityContext.User = new Developer(1);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IEmployeeService employeeService = new EmployeeService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => employeeService.GetEmployee(id: 0, pageNumber: 0));
        }

        [Fact]
        public void GetEmployee_FromDAL_CorrectMappingToEmployeeDTO()
        {
            // Arrange
            SecurityContext.User = new Manager(1);
            var expected = new Employee
            {
                Id = 1,
                Salary = 1,
                AuthorizationInfo = new AuthorizationInfo(),
                FirstName = "TestN",
                SecondName = "Test",
                WorkStatus = WorkStatus.Normal
            };
            var employeeService = GetEmployeeService(employeeToMock: expected);

            // Act
            EmployeeDTO actualEmployeeDto = employeeService.GetEmployee(id: 1, pageNumber: 0);

            // Assert
            Assert.True(
                actualEmployeeDto.Id == expected.Id
                && actualEmployeeDto.Salary == expected.Salary
                && actualEmployeeDto.FirstName == expected.FirstName
                && actualEmployeeDto.SecondName == expected.SecondName
                && actualEmployeeDto.WorkStatus == expected.WorkStatus);
        }

        private IEmployeeService GetEmployeeService(Employee employeeToMock)
        {
            var mockContext = new Mock<IUnitOfWork>();

            var mockDbSet = new Mock<IEmployeeRepository>();
            mockDbSet
                .Setup(x =>
                    x.Find(It.IsAny<Func<Employee, bool>>(),
                        It.IsAny<int>(),
                        It.IsAny<int>()))
                .Returns(
                    new List<Employee> {employeeToMock});

            mockContext
                .Setup(context =>
                    context.Employees)
                .Returns(mockDbSet.Object);

            IEmployeeService employeeService = new EmployeeService(mockContext.Object);

            return employeeService;
        }
    }
}