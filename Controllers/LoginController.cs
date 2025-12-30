using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
