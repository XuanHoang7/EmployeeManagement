using EmployeeManagement.DTO;
using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Services
{
    public interface IEmpoyeeServices
    {
        ResponseDTO GetEmployees(int? page = 1, int? pageSize = 10, string? key = "", string? sortBy = "id");
        ResponseDTO GetEmployeeByPhone(string phone);
        ResponseDTO GetEmployeeById(int id);

        ResponseDTO GetEmployeesByName(string name);

        ResponseDTO UpdateEmployee(Employee employee);

        ResponseDTO DeleteEmployee(int employeeId);

        ResponseDTO CreateEmployee(Employee employee);

    }
}
