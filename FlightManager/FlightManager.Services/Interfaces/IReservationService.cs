using FlightManager.Models;
using FlightManager.Web.ViewModels.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.Interfaces
{
    public interface IReservationService
    {
        void Create(ReservationViewModel reservation);
        bool Exists(int eGN, TicketType type, Flight flight);
    }
}
