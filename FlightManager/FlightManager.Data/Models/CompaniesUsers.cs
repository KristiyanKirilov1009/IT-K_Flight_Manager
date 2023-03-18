using FlightManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class CompaniesUsers
    {
        public CompaniesUsers()
        {
            
        }
        public CompaniesUsers(int companyID, int userID)
        {
            CompanyID = companyID;
            UserID = userID;
        }

        [ForeignKey("CompanyID")]
        public Company Company { get; set; }
        public int CompanyID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        public int UserID { get; set; }
    }
}
