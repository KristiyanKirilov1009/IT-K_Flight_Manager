using FlightManager.Data;
using FlightManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator, Employee")]
        public IActionResult Index()
        {
            var list = _context.ApplicationUsers.ToList();

            return View(list);
        }
    }
}
