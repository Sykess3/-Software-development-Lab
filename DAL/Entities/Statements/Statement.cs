using DAL.Enums;

namespace DAL.Entities.Statements
{
    public abstract class Statement
    {
        public string Message { get; }
        public StatementState State { get; set; }

        protected Statement(string message)
        {
            Message = message;
            State = StatementState.InProcess;
        }

        public abstract void Send();
    }
}