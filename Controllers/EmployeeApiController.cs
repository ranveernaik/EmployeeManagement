using EmployeeManagementCore.Models;
using EmployeeManagementCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeServices employeeServices;

        public EmployeeApiController(IEmployeeServices services)
        {
            employeeServices = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(employeeServices.GetAllEmployees());
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            employeeServices.AddEmployee(employee);
            return Created("", employee);
        }
    }
}
