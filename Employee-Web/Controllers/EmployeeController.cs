using System.Security.Claims;
using Application.DTOs;
using Application.Interfaces;
using Domain.Users;
using Employee_Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Web.Controllers
{
    [AuthorizeRole("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IUserService _userservice;
        public EmployeeController(IUserService userservice)
        {
            _userservice = userservice;
        }
        public IActionResult Index()
        {
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _userservice.GetAllUserRequest(userId);

            return View(model);
        }

        [HttpGet]
        public IActionResult NewRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewRequest(NewRequestDTO model)
        {
            if (!ModelState.IsValid) return View(model);
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            _userservice.AddRequest(model.StardDate, model.FinishDateDate, model.Reason, userId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int requestId)
        {
            var req = _userservice.GetRequestById(requestId);
            if (req == null) return NotFound();

            return View(req);
        }

    }
}
