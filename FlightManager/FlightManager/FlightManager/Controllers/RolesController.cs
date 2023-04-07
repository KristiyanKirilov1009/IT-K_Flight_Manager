using FlightManager.Data;
using FlightManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Controllers
{
    public class RolesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public RolesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Admin_Users()
        {

            return _context.Users != null ?
                        View(await _context.Users.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }

        public async Task<IActionResult> Admin_Flights()
        {

            return _context.Flights != null ?
                        View(await _context.Flights.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Flights'  is null.");

        }

        public async Task<IActionResult> Admin_Reservations()
        {

            return _context.Reservations != null ?
                        View(await _context.Reservations.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Reservations'  is null.");

        }

        [HttpGet]
        public async Task<IActionResult> Admin_MyProfile()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            return View(user);

        }

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Employee()
        {
            return _context.Flights != null ?
                        View(await _context.Flights.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Flights'  is null.");
        }

        public async Task<IActionResult> Employee_Reservations()
        {

            return _context.Reservations != null ?
                        View(await _context.Reservations.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Reservations'  is null.");
            

        }

        public async Task<IActionResult> Empl_Users()
        {

            return _context.Users != null ?
                        View(await _context.Users.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Empl_MyProfile()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            return View(user);

        }

        public IActionResult C_Saved()
        {
            return View();
        }
    }
}
