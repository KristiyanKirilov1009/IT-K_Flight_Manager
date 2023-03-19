using AutoMapper;
using FlightManager.Data.Data;
using FlightManager.Models;
using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    internal class ReservationService : IReservationService
    {
        private readonly FlightContext _context;
        private readonly IMapper _mapper;

        public ReservationService(IMapper mapper,FlightContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool Exists(int eGN, TicketType type,Flight flight)
        {
            Reservation? reservation =  _context.Reservations.Where(r => r.EGN == eGN && r.TicketType == type && r.Flight == flight).FirstOrDefault();

            if (reservation == null)
            {
                return false;
            }
            else
                return true;
        }

        public void Create(ReservationViewModel reservation)
        {
            Reservation? newReservation = _mapper.Map<Reservation>(reservation);

            _context.Reservations.Add(newReservation);
            _context.SaveChanges();
        }
    }
}
