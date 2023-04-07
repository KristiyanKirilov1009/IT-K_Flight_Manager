using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightManager.Data;
using FlightManager.Models;
using FlightManager.Models.ViewModels;
using AutoMapper;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace FlightManager.Controllers
{
    public class ReservationController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public ReservationController(IMapper mapper, ApplicationDbContext context, IEmailSender emailSender)
        {
            _mapper = mapper;
            _context = context;
            _emailSender = emailSender;
        }

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservations.Include(r => r.Flight);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Flight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservation/Create
        public IActionResult Create()
        {
            ViewData["FlightId"] = new SelectList(_context.Flights, "Id", "Id");
            var flightList = _context.Flights.ToList();
            ViewBag.List = flightList;
            return View();
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = _mapper.Map<Reservation>(model);
                reservation.Flight = _context.Flights.Where(f => f.Id == model.FlightId).FirstOrDefault();
                Flight flight = reservation.Flight;

                if ((flight.FilledSeatsEconomy + flight.FilledSeatsBuisness) + reservation.Passengers >= flight.PassangerCapacity + flight.BussinessClassCapacity)
                {
                    ModelState.AddModelError("Passengers", "Not enough available seats on the chosen flight");
                    var flightList = _context.Flights.ToList();
                    ViewBag.List = flightList;
                    return View(model);
                }
                _context.Add(reservation);
                await _context.SaveChangesAsync();

                return RedirectToAction("Create", "Passanger");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Reservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "Id", "Id", reservation.FlightId);
            return View(reservation);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,FlightId")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "Id", "Id", reservation.FlightId);
            return View(reservation);
        }

        // GET: Reservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Flight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservations'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
