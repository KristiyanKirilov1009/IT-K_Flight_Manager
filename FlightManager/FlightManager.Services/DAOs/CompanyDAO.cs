using FlightManager.Data.Data;
using FlightManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.DAOs
{
    public class CompanyDAO
    {
        private FlightContext context = new FlightContext();

        public Company GetCompany(string name)
        {
            return context.Companies.Where(c => c.CompanyName.Equals(name)).FirstOrDefault();
        }

        public int? GetCompanyId(string name)
        {
            return context
                .Companies
                .Where(c => c.CompanyName.Equals(name))
                .FirstOrDefault()?.CompanyID;
        }

        public CompaniesUsers GetByUserIDandCompanyID(int userID, int companyID)
        {
            return context.CompaniesUsers.Where(u => u.UserID.Equals(userID)
                                                                && u.CompanyID.Equals(companyID)).FirstOrDefault();
        }

        public void AddToCompaniesUsers(CompaniesUsers cu)
        {
            context.CompaniesUsers.Add(cu);
            context.SaveChanges();
        }
    }
}
