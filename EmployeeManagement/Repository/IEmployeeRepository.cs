using EmployeeManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees(int? page = 1, int? pageSize = 10, string? key = "", string? sortBy = "id");

        Employee? GetEmployeeByPhone(string phone);
        Employee? GetEmployeeById(int id);

        List<Employee> GetEmployeesByName(string name);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        void CreateEmployee(Employee employee);
        public bool IsSaveChange();
    }
}
