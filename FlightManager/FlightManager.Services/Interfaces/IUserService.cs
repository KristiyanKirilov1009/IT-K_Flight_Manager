using FlightManager.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.Interfaces
{
    public interface IUserService
    {
        void Create(CreateUserViewModel newUser);
        bool Exist(string username);
        bool TruePassword(string password);
    }
}
