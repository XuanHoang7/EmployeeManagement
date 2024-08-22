using EmployeeManagement.Data;
using EmployeeManagement.Models.Entities;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        List<Employee> IEmployeeRepository.GetEmployees(int? page = 1, int? pageSize = 10, string? key = "", string? sortBy = "id")
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(key))
            {
                query = query.Where(emp => emp.Name.ToLower().Contains(key.ToLower()));
            }

            switch (sortBy)
            {
                case "Name":
                    query = query.OrderBy(emp => emp.Name);
                    break;
                case "Email":
                    query = query.OrderBy(emp => emp.Email);
                    break;
                case "Phone":
                    query = query.OrderBy(emp => emp.Phone);
                    break;
                case "Salary":
                    query = query.OrderBy(emp => emp.Salary);
                    break;
                default:
                    query = query.OrderBy(emp => emp.Id);
                    break;
            }
            if (page == null || pageSize == null) { return query.ToList(); }
            else
                return query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
        }
        void IEmployeeRepository.CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        void IEmployeeRepository.DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
        }


        Employee? IEmployeeRepository.GetEmployeeByPhone(string phone)
        {   
           return _context.Employees.FirstOrDefault(
               emp => emp.Phone != null && emp.Phone.Equals(phone)); 
        }

        

        List<Employee> IEmployeeRepository.GetEmployeesByName(string name)
        {
            return _context.Employees.Where(emp => emp.Name.Equals(name)).ToList();
        }

        void IEmployeeRepository.UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        Employee? IEmployeeRepository.GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(emp => emp.Id.Equals(emp.Id));
        }
        public bool IsSaveChange()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
