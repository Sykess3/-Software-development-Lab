using System;
using BLL.Factories.Interfaces;
using DAL.Entities.Statements;
using DAL.Enums;

namespace BLL.Factories.Impl
{
    public class StatementFactory : IStatementFactory
    {
        public Statement Create(StatementType type, string message)
        {
            switch (type)
            {
                case StatementType.Education:
                    return new EducationStatement(message);
                case StatementType.Certification:
                    return new CertificationStatement(message);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}