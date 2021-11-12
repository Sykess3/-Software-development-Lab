namespace DAL.Entities
{
    public class EmployeeData
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Salary { get; set; }
        public PositionInCompany Position { get; set; }
        public WorkStatus WorkStatus { get; set; }
        public AuthorizationInfo AuthorizationInfo { get; set; }
    }
}