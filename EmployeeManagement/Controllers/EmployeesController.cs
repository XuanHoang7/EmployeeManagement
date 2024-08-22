using EmployeeManagement.Models.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpoyeeServices _employeeServices;
        public EmployeesController(IEmpoyeeServices employeeServices) {
            _employeeServices = employeeServices;
        }
        [HttpGet]
        public IActionResult GetAllEmployees(int? page = 1, int? pageSize = 10, string? key = "", string? sortBy = "id") { 
            var res = _employeeServices.GetEmployees(page, pageSize, key, sortBy);
            return StatusCode(res.code, res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var res = _employeeServices.GetEmployeeById(id);
            return StatusCode(res.code, res);
        }

        [HttpGet("phone/{phone}")]
        public IActionResult GetEmployeeByPhone(string phone)
        {
            var res = _employeeServices.GetEmployeeByPhone(phone);
            return StatusCode(res.code, res);
        }

        [HttpGet("{name}")]
        public IActionResult GetEmployeeByName(string name)
        {
            var res = _employeeServices.GetEmployeesByName(name);
            return StatusCode(res.code, res);
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            var res = _employeeServices.CreateEmployee(employee);
            return StatusCode(res.code, res);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id) 
        { 
            var res = _employeeServices.DeleteEmployee(id); 
            return StatusCode(res.code, res); 
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var res = _employeeServices.UpdateEmployee(employee);
            return StatusCode(res.code, res);
        }
    }
}
