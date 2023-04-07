using FlightManager.Data;
using FlightManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FlightManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Flights != null ?
                        View(await _context.Flights.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Flights'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Book() {
            return View();
        }

        public IActionResult AllFlights() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Panel()
        {
            var currentUserName = HttpContext.User.Identity.Name;
            ApplicationUser user = _context.Users.Where(u => u.UserName == currentUserName).FirstOrDefault();
            var currentUserRole = _context.UserRoles.Where(r => r.UserId == user.Id).FirstOrDefault();
            var adminId = _context.Roles.Where(r => r.Name == "Administrator").FirstOrDefault();
            var employeeId = _context.Roles.Where(r => r.Name == "Employee").FirstOrDefault();

            if (currentUserRole.RoleId == adminId.Id)
            {
                return RedirectToAction("Admin_Users", "Roles");
            }
            else if (currentUserRole.RoleId == employeeId.Id)
            {
                return RedirectToAction("Employee", "Roles");
            }
            return NotFound();
        }

    }
}