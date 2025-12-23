using EmployeeManagementCore.Data;
using EmployeeManagementCore.Models;
using EmployeeManagementCore.Services;
using EmployeeManagementCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementCore.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeServices employeeServices;
        public EmployeeController(IEmployeeServices services)
        {
            employeeServices = services;
        }

        public IActionResult Index()
        {
            var employees = employeeServices.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            employeeServices.AddEmployee(employee);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            return View(EmployeeStore.Employees);
        }

     
    }
}
