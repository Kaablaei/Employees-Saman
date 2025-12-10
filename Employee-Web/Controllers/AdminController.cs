using System.Collections.Generic;
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
        private readonly IDailyCacheService _dailyCache;
        public AdminController(IAdminService adminService, IDailyCacheService dailyCache)
        {
            _dailyCache = dailyCache;
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            var stats = _dailyCache.GetStats();

            ViewData["TotalToday"] = stats.Total;
            ViewData["AcceptedToday"] = stats.Accepted;
            ViewData["RejectedToday"] = stats.Rejected;

            var model = _adminService.GetPendingRequests();
            return View(model);
        }
        public IActionResult Users()
        {
            var model = _adminService.GetAllUsers();
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


        [HttpGet]
        public IActionResult Response(long RequestId)
        {
            var model = _adminService.GetRequestById(RequestId);
            if (model == null) return NotFound();

            return View(model);
        }
        
        [HttpPost]
        public IActionResult Response(bool Accepted , string? response, long RequestId)
        {
            var model = _adminService.ChangeRequestStatus(Accepted, response, RequestId);

            return RedirectToAction(nameof(Index));
        }



    }
}
