using FlightManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class CompaniesUsers
    {
        public CompaniesUsers(int companyID, int userID)
        {
            CompanyID = companyID;
            UserID = userID;
        }

        public Company Company { get; set; }
        public int CompanyID { get; set; }

        public User User { get; set; }
        public int UserID { get; set; }
    }
}
