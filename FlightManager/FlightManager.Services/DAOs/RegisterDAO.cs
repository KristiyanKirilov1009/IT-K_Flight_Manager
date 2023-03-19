using FlightManager.Data.Data;
using FlightManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.DAOs
{
    public class RegisterDAO
    {
        private FlightContext context = new FlightContext();

        public User GetUserByID(int id)
        {
            return context.Users.Where(u => u.ID.Equals(id)).FirstOrDefault();
        }

        public User GetByUsername(int username)
        {
            return context.Users.Where(u => u.UserName.Equals(username)).FirstOrDefault();
        }

        public void Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
