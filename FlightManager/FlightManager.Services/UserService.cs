using AutoMapper;
using FlightManager.Data.Data;
using FlightManager.Data.Migrations;
using FlightManager.Data.Models;
using FlightManager.Models;
using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Users;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly FlightContext _context;

        public UserService(IMapper mapper, FlightContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Create(CreateUserViewModel user)
        {
            User newUser = _mapper.Map<User>(user);
            newUser.Password = HashPassword(newUser.Password);

            Company company = GetCompany(newUser.Company.CompanyName);
            company.Users.Add(newUser);

            GiveARole(newUser);

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public bool Exist(string username)
        {
            User? user = _context.Users.Where(u => u.UserName == username).FirstOrDefault();

            if(user == null)
            {
                return false;
            }
            return true;
        }

        public bool TruePassword(string password)
        {
            string hashedPass = HashPassword(password);

            User? user = _context.Users.Where(u => u.Password == hashedPass).FirstOrDefault();

            if(user == null)
            {
                return false;
            }
            return true;
        }

        private void GiveARole(User user)
        {
            if(user.Company.Users.Count == 1) 
            {
                user.Role = Roles.Admin;
            }
            else
            {
                user.Role = Roles.Employee;
            }
        }

        private Company GetCompany(string companyName)
        {
            Company? company = _context.Companies.Where(c => c.CompanyName == companyName).FirstOrDefault();

            return company;
        }
        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedpassword = hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedpassword);
        }
    }
}
