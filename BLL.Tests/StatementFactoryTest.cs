using System;
using BLL.Factories.Impl;
using DAL.Entities.Statements;
using DAL.Enums;
using Xunit;

namespace BLL.Tests
{
    public class StatementFactoryTest
    {

        [Fact]
        public void CreateStatement_InputEducationStatementType_ReturnEducationStatement()
        {
            // Arrange
            var statementFactory = new StatementFactory();
            // Act
            var statement = statementFactory.Create(StatementType.Education, String.Empty);
            // Assert
            Assert.True(statement.GetType() == typeof(EducationStatement));
        }
    }
}