using FlightManager.Data.Data;
using FlightManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using System.Text;
using System;
using System.Security.Cryptography;
using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Companies;
using FlightManager.Models;

namespace FlightManager.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _company;
        private FlightContext _context = new FlightContext();

        public CompanyController(ICompanyService company)
        {
            _company = company;
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
        public IActionResult Create(CreateCompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                if(!(_company.Exist(company.CompanyName)))
                {
                    _company.CreateCompany(company);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "There is such a company!");
                    return View(company);
                }
            }

            return View(company);
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
