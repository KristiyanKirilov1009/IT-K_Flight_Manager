using FlightManager.Data.Data;
using FlightManager.Models;
using FlightManager.Services.DAOs;
using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace FlightManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _login;
        private LoginDAO loginDAO = new LoginDAO();
        private FlightContext _context = new FlightContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel userViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = loginDAO.GetUserByUsername(userViewModel.UserName);

                if(!(_context.Users.Any(u => u.UserName.Equals(userViewModel.UserName))))
                {
                    ModelState.AddModelError(string.Empty, "There is no such a user!");
                    return View(userViewModel);
                }
                if(!(_context.Users.Any(u => u.Password.Equals(HashPassword(userViewModel.Password)))))
                {
                    ModelState.AddModelError(string.Empty, "Wrong password!");
                    return View(userViewModel);
                }
                if (loginDAO.InCompany(user.ID, user.CompanyID) != null)
                {
                    ModelState.AddModelError(string.Empty, "This user is not in this company!");
                    return View(userViewModel);
                }
                if(!(_context.Companies.Where(c => c.CompanyName.Equals(userViewModel.CompanyName)).FirstOrDefault() != null))
                {
                    ModelState.AddModelError(string.Empty, "There is no such a company");
                    return View(userViewModel);
                }
                if(!(_context.Companies.Where(c => c.Password.Equals(HashPassword(userViewModel.CompanyPassword))).FirstOrDefault() != null))
                {
                    ModelState.AddModelError(string.Empty, "Wrong company password!");
                    return View(userViewModel);
                }
                else
                {
                    _login.LogIn(userViewModel);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(userViewModel);
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
