using FlightManager.Models;
using FlightManager.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.Interfaces
{
    public interface ILoginService
    {
        void LogIn(LoginViewModel user);
    }
}
