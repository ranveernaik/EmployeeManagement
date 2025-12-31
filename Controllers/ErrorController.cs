using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementCore.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
