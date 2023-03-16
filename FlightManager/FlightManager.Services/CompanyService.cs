using AutoMapper;
using FlightManager.Data.Data;
using FlightManager.Data.Models;
using FlightManager.Models;
using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly FlightContext _context;

        public CompanyService(IMapper mapper, FlightContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void CreateCompany(CreateCompanyViewModel company)
        {
            Company newCompany = _mapper.Map<Company>(company);
            newCompany.Password = HashPassword(newCompany.Password);

            _context.Companies.Add(newCompany);
            _context.SaveChanges();

        }

        public bool Exist(string companyName)
        {
            Company? company = _context.Companies.Where(c => c.CompanyName == companyName).FirstOrDefault();

            if (company == null)
                return false;
            else
                return true;
        }

        public bool TruePassword(string password)
        {
            string hashedPass = HashPassword(password);

            Company? company = _context.Companies.Where(u => u.Password == hashedPass).FirstOrDefault();

            if (company == null)
            {
                return false;
            }
            return true;
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
