using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
           // var model = _adminService.AllUsers();
            return View();
        }    
        public IActionResult Users()
        {
           var model = _adminService.AllUsers();
            return View(model);
        }

        public IActionResult NewUser()
        {
           
            return View();
        }

    }
}
