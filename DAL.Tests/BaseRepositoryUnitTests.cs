using System;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        class TestAuthorizationInfoRepository : BaseRepository<AuthorizationInfo>
        {
            public TestAuthorizationInfoRepository(DbContext context) : base(context)
            {
            }
        }

        [Fact]
        public void Create_InputAuthorizationInfoInstance_CalledAddMethodOfDBSetWithAuthorizationInfoInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<EmployeeContext>()
                .Options;
            var mockContext = new Mock<EmployeeContext>(opt);
            var mockDbSet = new Mock<DbSet<AuthorizationInfo>>();
            mockContext
                .Setup(context =>
                    context.Set<AuthorizationInfo>(
                    ))
                .Returns(mockDbSet.Object);
            var repository = new TestAuthorizationInfoRepository(mockContext.Object);

            var expectedAuthorizationInfo = new Mock<AuthorizationInfo>().Object;

            //Act
            repository.Create(expectedAuthorizationInfo);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedAuthorizationInfo
                ), Times.Once());
        }

        [Fact]
        public void Delete_InputEmployeeId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<EmployeeContext>()
                .Options;
            var mockContext = new Mock<EmployeeContext>(opt);
            var mockDbSet = new Mock<DbSet<AuthorizationInfo>>();
            mockContext
                .Setup(context =>
                    context.Set<AuthorizationInfo>(
                    ))
                .Returns(mockDbSet.Object);
            var repository = new TestAuthorizationInfoRepository(mockContext.Object);

            var expectedAuthorizationInfo = new AuthorizationInfo() {EmployeeId = 1};
            mockDbSet.Setup(
                mock => mock.Find(expectedAuthorizationInfo.EmployeeId))
                .Returns(expectedAuthorizationInfo);

            //Act
            repository.Delete(expectedAuthorizationInfo.EmployeeId);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedAuthorizationInfo.EmployeeId
                ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedAuthorizationInfo
                ), Times.Once());
        }

        [Fact]
        public void Get_InputEmployeeId_CalledFindMethodOfDBSetWithCorrectEmployeeId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<EmployeeContext>()
                .Options;
            var mockContext = new Mock<EmployeeContext>(opt);
            var mockDbSet = new Mock<DbSet<AuthorizationInfo>>();
            mockContext
                .Setup(context =>
                    context.Set<AuthorizationInfo>(
                    ))
                .Returns(mockDbSet.Object);

            var expectedAuthorizationInfo = new AuthorizationInfo() {EmployeeId = 1};
            mockDbSet.Setup(mock => mock.Find(expectedAuthorizationInfo.EmployeeId))
                .Returns(expectedAuthorizationInfo);
            var repository = new TestAuthorizationInfoRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedAuthorizationInfo.EmployeeId);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedAuthorizationInfo.EmployeeId
                ), Times.Once());
            Assert.Equal(expectedAuthorizationInfo, actualStreet);
        }
    }
}