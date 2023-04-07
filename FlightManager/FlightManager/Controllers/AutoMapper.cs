using AutoMapper;
using FlightManager.Data.Migrations;
using FlightManager.Models;
using FlightManager.Models.ViewModels;

namespace FlightManager.Controllers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<PassengerViewModel, Passengers>(); 
            CreateMap<ReservationViewModel, Reservation>();
        }
    }
}
