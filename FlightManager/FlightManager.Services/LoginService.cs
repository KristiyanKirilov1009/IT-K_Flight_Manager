using AutoMapper;
using FlightManager.Data.Data;
using FlightManager.Models;
using FlightManager.Services.DAOs;
using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        private readonly FlightContext _context;
        private LoginDAO loginDAO = new LoginDAO();

        public LoginService(IMapper mapper, FlightContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void LogIn(LoginViewModel user)
        {
            string hashedPassword = HashPassword(user.Password);

            loginDAO.GetUserByUsername(user.UserName, hashedPassword);

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
