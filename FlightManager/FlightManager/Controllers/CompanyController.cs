using FlightManager.Data.Data;
using FlightManager.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Controllers
{
    public class CompanyController : Controller
    {
        private readonly FlightContext _flightContext;

        public CompanyController(FlightContext flightContext)
        {
            _flightContext = flightContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companies = _flightContext.Companies;
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            _flightContext.Companies.Add(company);
            _flightContext.SaveChangesAsync();
            return View();
        }
    }
}
