using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewRequest(NewRequestDTO model)
        {
            return View();
        }

        public IActionResult Detail(int requestId)
        {
            return View();
        }

    }
}
