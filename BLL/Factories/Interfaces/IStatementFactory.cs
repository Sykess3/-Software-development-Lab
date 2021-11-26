using DAL.Entities.Statements;
using DAL.Enums;

namespace BLL.Factories.Interfaces
{
    public interface IStatementFactory
    {
        Statement Create(StatementType type, string message);
    }
}