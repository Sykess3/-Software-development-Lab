using DAL.Enums;

namespace DAL.Entities.Statements
{
    public class CertificationStatement : Statement
    {
        public CertificationStatement(string message)
        :base(message)
        {
        }
        

        public override void Send()
        {
            
        }
    }
}