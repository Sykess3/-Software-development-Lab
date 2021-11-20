using DAL.Enums;

namespace DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Salary { get; set; }
        public WorkStatus WorkStatus { get; set; }
        public AuthorizationInfo AuthorizationInfo { get; set; }
    }
}