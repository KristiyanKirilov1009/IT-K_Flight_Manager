using FlightManager.Web.ViewModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.Interfaces
{
    public interface ICompanyService
    {
        void CreateCompany(CreateCompanyViewModel createCompanyViewModel);
        bool Exist(string companyName);
        bool TruePassword(string password);
    }
}
