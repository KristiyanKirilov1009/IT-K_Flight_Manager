using AutoMapper;
using AutoMapper.Configuration.Conventions;
using FlightManager.Data.Data;
using FlightManager.Data.Models;
using FlightManager.Models;
using FlightManager.Services.DAOs;
using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        private CompaniesUsers companiesUsers = new CompaniesUsers();
        private CompanyDAO companyDAO = new CompanyDAO();
        private UserDAO userDAO = new UserDAO();


        public UserService(IMapper mapper, FlightContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Create(CreateUserViewModel user)
        {
            User newUser = _mapper.Map<User>(user);
            newUser.Password = HashPassword(newUser.Password);

            _context.Users.Add(newUser);
            _context.SaveChanges();

            var company = companyDAO.GetCompany(user.CompanyName);

            if (company != null)
            {
                newUser.CompanyID = company.CompanyID;

                _context.CompaniesUsers
                    .Add(new CompaniesUsers()
                    {
                        CompanyID = company.CompanyID,
                        UserID = newUser.ID
                    });

                _context.SaveChanges();

                if (company.Users.Count == 1)
                {
                    GiveARole(company.CompanyID, newUser.ID, Roles.Admin);
                }
                else
                {
                    GiveARole(company.CompanyID, newUser.ID, Roles.Employee);
                }
            }

        }

        public bool Exist(string username)
        {
            User? user = _context.Users.Where(u => u.UserName == username).FirstOrDefault();

            if (user == null)
            {
                return false;
            }
            return true;
        }

        public bool TruePassword(string password)
        {
            string hashedPass = HashPassword(password);

            User? user = _context.Users.Where(u => u.Password == hashedPass).FirstOrDefault();

            if (user == null)
            {
                return false;
            }
            return true;
        }

        private void GiveARole(int companyID, int userID, Roles role)
        {
            var userCompany = _context.CompaniesUsers.FirstOrDefault(c => c.CompanyID == companyID && c.UserID == userID);
            if (userCompany != null)
            {
                userCompany.User.Role = role;
            }
            _context.SaveChanges();
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
