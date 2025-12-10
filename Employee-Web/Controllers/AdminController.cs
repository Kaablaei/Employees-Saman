using Microsoft.AspNetCore.Mvc;

namespace Employee_Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
