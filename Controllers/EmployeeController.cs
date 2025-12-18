using EmployeeManagementCore.Data;
using EmployeeManagementCore.Models;
using EmployeeManagementCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementCore.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                return View(employeeViewModel);
            }
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
    }
}
