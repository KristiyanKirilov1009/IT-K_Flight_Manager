using FlightManager.Data.Data;
using FlightManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using System.Text;
using System;
using System.Security.Cryptography;
using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Companies;

namespace FlightManager.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _company;


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
                    return View(company);
                }
            }

            return View(company);
        }
    }
}
