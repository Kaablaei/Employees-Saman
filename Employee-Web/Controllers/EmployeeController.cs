using Microsoft.AspNetCore.Mvc;

namespace Employee_Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
