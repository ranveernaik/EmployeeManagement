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
            ViewBag.Message = "Employee Created Successfully!";
            return View();
        }
    }
}
