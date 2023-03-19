using FlightManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using FlightManager.Web.ViewModels.Flights;
using AutoMapper;
using FlightManager.Data.Data;

namespace FlightManager.Controllers
{
    public class ReservationController : Controller
    {
        private readonly FlightContext _context;
        private readonly IReservationService _Reservation;

        public ReservationController(IReservationService reservation)
        {
            _Reservation = reservation;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reserv()
        {
            return View("Create");
        }

        public IActionResult Create(ReservationViewModel reservation)
        {
            if (ModelState.IsValid)
            {
                if (_Reservation.Exists(reservation.EGN,reservation.TicketType,reservation.Flight))
                {
                    _Reservation.Create(reservation);
                }
            }
            return View(reservation);
        }
    }
}
