using FlightManager.Data.Data;
using FlightManager.Models;
using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace FlightManager.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _user;
        private FlightContext _context = new FlightContext();

        public RegisterController(IUserService user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel user)
        {
            if (ModelState.IsValid)
            {

                if (_context.Users.Any(u => u.UserName.Equals(user.UserName)))
                {
                    ModelState.AddModelError(string.Empty, "This user already exists!");
                    return View(user);
                }
                else if (!(_context.Companies.Any(c => c.CompanyName.Equals(user.CompanyName))))
                {
                    ModelState.AddModelError(string.Empty, "There is no such a company!");
                    return View(user);
                }
                else if (!(_context.Companies.Any(c => c.Password.Equals(HashPassword(user.CompanyPassword)))))
                {
                    ModelState.AddModelError(string.Empty, "Wrong company password!");
                    return View(user);
                }
                else
                {
                    _user.Create(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(user);
        }

        private IActionResult CustomValidation(CreateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.UserName.Equals(user.UserName)))
                {
                    ModelState.AddModelError(string.Empty, "This user already exists!");
                    return View(user);
                }
                else if (!(_context.Companies.Any(c => c.CompanyName.Equals(user.CompanyName))))
                {
                    ModelState.AddModelError(string.Empty, "There is no such a company!");
                    return View(user);
                }
                else if (!(_context.Companies.Any(c => c.Password.Equals(user.CompanyPassword))))
                {
                    ModelState.AddModelError(string.Empty, "Wrong company password!");
                    return View(user);
                }
                return View(user);
            }
            else
            {
                return View(user);
            }
        }
        private static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedpassword = hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedpassword);
        }
    }
}
