using FlightManager.Data.Data;
using FlightManager.Data.Models;
using FlightManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.DAOs
{
    public class LoginDAO
    {
        private FlightContext _context = new FlightContext();

        public User GetUserByID(int id)
        {
            return _context.Users.Where(u => u.ID.Equals(id)).FirstOrDefault();
        }

        public User GetUserByUsername(string username, string password)
        {
            return _context.Users.Where(u => u.UserName.Equals(username) && u.Password.Equals(password)).FirstOrDefault();
        }

        public CompaniesUsers InCompany(int userID, int companyID)
        {
            return _context.CompaniesUsers.Where(cu => cu.UserID.Equals(userID) && cu.CompanyID.Equals(companyID)).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.Where(u => u.UserName.Equals(username)).FirstOrDefault();
        }
    }
}
