using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountingServise _accountigService;

        public HomeController(IAccountingServise accountigService)
        {
            _accountigService = accountigService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginUserDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var LoginUser = _accountigService.GetUserInfo(model.UserName, model.Password);
            if (LoginUser != null)
            {
                // Identty

                if (LoginUser.Role == Domain.Users.Enums.UserRole.Admin) return RedirectToAction("Index", "Admin");

                return RedirectToAction("Index", "Employee");
            }
            ModelState.AddModelError("UserName", "Invalid username or password");
            return View(model);
        }



    }
}
