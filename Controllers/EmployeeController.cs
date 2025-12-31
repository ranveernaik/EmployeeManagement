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
        public readonly ILogger<EmployeeController> employeeLogger;
        public EmployeeController(IEmployeeServices services, ILogger<EmployeeController> logger)
        {
            employeeServices = services;
            employeeLogger = logger;
        }

        public IActionResult Index()
        {
            var employees = employeeServices.GetAllEmployees();
            employeeLogger.LogInformation("Getting Employees");
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
            try 
            {
                employeeServices.AddEmployee(employee);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                employeeLogger.LogError(ex, "Error while adding employee");
                return RedirectToAction("Error", "Error");
            }

            
        }

        public IActionResult Edit(int id)
        {
            var employee = employeeServices.GetEmployee(id);
            if (employee == null)
            {
                employeeLogger.LogWarning("Employee Not Found. Id : {Id}", id);
                return NotFound();
            }
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
