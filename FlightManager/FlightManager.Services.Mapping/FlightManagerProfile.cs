using AutoMapper;
using FlightManager.Data.Models;
using FlightManager.Models;
using FlightManager.Web.ViewModels.Companies;
using FlightManager.Web.ViewModels.Users;
using FlightManager.Web.ViewModels.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.Mapping
{
    public class FlightManagerProfile : Profile
    {
        public FlightManagerProfile()
        {
            CreateMap<CreateUserViewModel, User>();
            CreateMap<CreateCompanyViewModel, Company>();
            CreateMap<ReservationViewModel, Reservation>();
        }
    }
}
