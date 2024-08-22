using EmployeeManagement.DTO;
using EmployeeManagement.Models.Entities;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Services
{
    public class EmployeeServices : IEmpoyeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        ResponseDTO IEmpoyeeServices.CreateEmployee(Employee employee)
        {
            if(employee != null)
            {
                _employeeRepository.CreateEmployee(employee);
                if (_employeeRepository.IsSaveChange()) return new ResponseDTO()
                {
                    code = 200,
                    message = "Success",
                    description = null
                };
                else return new ResponseDTO()
                {
                    code = 400,
                    message = "Faile",
                    description = null
                };
            }
            return new ResponseDTO()
            {
                code = 400,
                message = "Faile",
                description = null
            };
        }


        ResponseDTO IEmpoyeeServices.DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if(employee != null)
            {
                _employeeRepository.DeleteEmployee(employee);
                if (_employeeRepository.IsSaveChange()) return new ResponseDTO()
                {
                    code = 200,
                    message = "Success",
                    description = null
                };
                else return new ResponseDTO()
                {
                    code = 400,
                    message = "Faile",
                    description = null
                };
            }
            return new ResponseDTO()
            {
                code = 400,
                message = "Faile",
                description = null
            };
        }

        ResponseDTO IEmpoyeeServices.GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeById(id);
                if (employee != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = employee
                    };
                else return new ResponseDTO()
                {
                    code = 200,
                    message = "Id is not exists",
                    description = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    code = 400,
                    message = ex.Message,
                    description = null
                };
            }
        }


        ResponseDTO IEmpoyeeServices.GetEmployeeByPhone(string phone)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeByPhone(phone);
                if (employee != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = employee
                    };
                else return new ResponseDTO()
                {
                    code = 200,
                    message = "Phone is not exists",
                    description = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    code = 400,
                    message = ex.Message,
                    description = null
                };
            }
        }

        ResponseDTO IEmpoyeeServices.GetEmployees(int? page, int? pageSize, string? key, string? sortBy)
        {
            try
            {
                var userDTOs = new List<Employee>();
                var employees = _employeeRepository.GetEmployees(page, pageSize, key, sortBy);

                return new ResponseDTO()
                {
                    code = 200,
                    message = "Success",
                    description = employees
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    code = 400,
                    message = ex.Message,
                    description = null
                };
            }
        }

        ResponseDTO IEmpoyeeServices.GetEmployeesByName(string name)
        {
            try
            {
                var employees = _employeeRepository.GetEmployeesByName(name);
                if (employees != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = employees
                    };
                else return new ResponseDTO()
                {
                    code = 200,
                    message = "Name is not exists",
                    description = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    code = 400,
                    message = ex.Message,
                    description = null
                };
            }
        }

        ResponseDTO IEmpoyeeServices.UpdateEmployee(Employee employee)
        {
            var employeeCheck = _employeeRepository.GetEmployeeById(employee.Id);

            if (employeeCheck == null) return new ResponseDTO()
            {
                code = 200,
                message = employee.Id + " is not have account",
                description = null
            };

           

            _employeeRepository.UpdateEmployee(employee);
            if (_employeeRepository.IsSaveChange()) return new ResponseDTO()
            {
                code = 200,
                message = "Success",
                description = employee
            };
            else return new ResponseDTO()
            {
                code = 400,
                message = "Faile",
                description = null
            };
        }
    }
}
