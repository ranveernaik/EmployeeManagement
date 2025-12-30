using EmployeeManagementCore.Data;
using EmployeeManagementCore.Models;
using EmployeeManagementCore.Services;
using EmployeeManagementCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Edit(int id)
        {
            var employee = employeeServices.GetEmployee(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return View(employee);
            }

            employeeServices.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var employee = employeeServices.GetEmployee(id);
            if(employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            employeeServices.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
