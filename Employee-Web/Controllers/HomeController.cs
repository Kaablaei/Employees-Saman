using System.Data;
using System.Security.Claims;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
 
                var clime = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,model.UserName),
                    new Claim(ClaimTypes.Role, LoginUser.Role.ToString())
                };
                var identity = new ClaimsIdentity(clime, CookieAuthenticationDefaults.AuthenticationScheme);
                var prins = new ClaimsPrincipal(identity);
                var propertice = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(prins, propertice);

                if (LoginUser.Role == Domain.Users.Enums.UserRole.Admin) return RedirectToAction("Index", "Admin");

                return RedirectToAction("Index", "Employee");
            }
            ModelState.AddModelError("UserName", "Invalid username or password");
            return View(model);
        }


        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

    }
}
