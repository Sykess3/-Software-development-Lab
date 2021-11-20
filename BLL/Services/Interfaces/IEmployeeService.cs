using System.Collections;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO GetEmployee(int id, int pageNumber);
    }
}