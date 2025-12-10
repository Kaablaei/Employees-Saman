using Application.DTOs;
using Application.Interfaces;
using Employee_Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Web.Controllers
{
    [AuthorizeRole("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            var model = _adminService.AllUsers();
            return View(model);
        }

        [HttpGet]
        public IActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewUser(NewUserDTO mode)
        {
            if(!ModelState.IsValid) return View(mode);
            _adminService.AddEmployee(mode.UserName, mode.Password);
            return RedirectToAction(nameof(Users));
        }
    }
}
