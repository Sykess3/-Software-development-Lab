using DAL.Enums;

namespace DAL.Entities.Statements
{
    public class EducationStatement : Statement
    {
        public EducationStatement(string message)
            : base(message)
        {
        }

        public override void Send()
        {
        }
    }
}