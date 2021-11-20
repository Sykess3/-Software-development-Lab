using DAL.Enums;

namespace BLL.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Salary { get; set; }
        public WorkStatus WorkStatus { get; set; }
    }
}