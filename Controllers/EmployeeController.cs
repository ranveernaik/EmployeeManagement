using EmployeeManagementCore.Data;
using EmployeeManagementCore.Models;
using EmployeeManagementCore.Services;
using EmployeeManagementCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementCore.Controllers
{
    public class EmployeeController : Controller
    {
        //----------------------------Day01-----------------------------------------------
        public IActionResult Index()
        {
            var employees = employeeServices.GetAllEmployees(); //-------Day 04
            return View(employees); //--------Day04
        }

        //---------------------------------Day02---------------------------------------------

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeViewModel);
            }

            //--------------------------------------Day03------------------------------------------
            var Employee = new Employee
            {
                Id = EmployeeStore.Employees.Count + 1,
                Name = employeeViewModel.Name,
                Email = employeeViewModel.Email,
                Department = employeeViewModel.Department
            };

            EmployeeStore.Employees.Add(Employee);

            TempData["Success"] = "Employee Created Successfully";

            return RedirectToAction("EmployeeList");
        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            return View(EmployeeStore.Employees);
        }

        public readonly IEmployeeServices employeeServices;
        public EmployeeController(IEmployeeServices services)
        {
            employeeServices = services;
        }
    }
}
