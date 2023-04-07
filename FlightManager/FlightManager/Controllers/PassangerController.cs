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
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace FlightManager.Controllers
{
    public class PassangerController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PassangerController(ApplicationDbContext context, IMapper mapper,IEmailSender emailSender)
        {
            _context = context;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        // GET: Passanger
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Passengers.Include(p => p.Reservation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Passanger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passanger = await _context.Passengers
                .Include(p => p.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passanger == null)
            {
                return NotFound();
            }

            return View(passanger);
        }

        // GET: Passanger/Create
        public IActionResult Create()
        {
            return View();
        }

        public bool HasSpecialChars(string s)
        {
            var withoutSpecial = new string(s.Where(c => Char.IsLetterOrDigit(c)
                                                        || Char.IsWhiteSpace(c)).ToArray());

            if (s != withoutSpecial)
            {
                return true;
            }

            return false;
        }

        // POST: Passanger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PassengerViewModel model)
        {
            if (ModelState.IsValid)
            {

                if ((model.FirstName.Any(char.IsDigit) && HasSpecialChars(model.FirstName)) || (model.MiddleName.Any(char.IsDigit)&& HasSpecialChars(model.MiddleName)) || (model.LastName.Any(char.IsDigit) && HasSpecialChars(model.LastName)))
                {
                    ModelState.AddModelError("LastName", "Name can't contains numbers or specail symbols!");
                    return View(model);
                }

                Reservation reservation = _context.Reservations.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                reservation.Flight = _context.Flights.Where(f => f.Id == reservation.FlightId).FirstOrDefault();

                Passanger passanger = new Passanger();
                passanger.FirstName = model.FirstName;
                passanger.MiddleName = model.MiddleName;
                passanger.LastName = model.LastName;
                passanger.Nationality = model.Nationality;
                passanger.UCN = model.UCN;
                passanger.TicketType = model.TicketType;
                passanger.Reservation = reservation;
                Flight flight = reservation.Flight;

                reservation.CompletedPassengers++;
                _context.Update(reservation);

                if (reservation.CompletedPassengers <= reservation.Passengers)
                {
                    if (passanger.TicketType == TicketType.Economy)
                    {
                        if (flight.FilledSeatsEconomy < (flight.PassangerCapacity - flight.BussinessClassCapacity))
                        {
                            reservation.Flight.FilledSeatsEconomy++;
                            _context.Update(reservation.Flight);

                            _context.Add(passanger);
                            _context.SaveChanges();
                        }
                    }
                    else if (passanger.TicketType == TicketType.Buisness)
                    {
                            reservation.Flight.FilledSeatsBuisness++;
                            _context.Update(reservation.Flight);

                            _context.Add(passanger);
                            _context.SaveChanges();
                    }
                }
                if (reservation.CompletedPassengers != reservation.Passengers)
                {
                    return RedirectToAction("Create");
                }
                await _emailSender.SendEmailAsync(reservation.Email, "Reservation created successfully!",
                       $"Your reservation was made successfully!\n{reservation.Flight.LocationFrom} - {reservation.Flight.LocationTo}");

                return View("~/Views/Reservation/Complete.cshtml");
            }
            return RedirectToAction("Index", "Home");
            //return View("Complete");
        }

        // GET: Passanger/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passanger = await _context.Passengers.FindAsync(id);
            if (passanger == null)
            {
                return NotFound();
            }
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id", passanger.ReservationId);
            return View(passanger);
        }

        // POST: Passanger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,UCN,Nationality,TicketType,ReservationId")] Passanger passanger)
        {
            if (id != passanger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passanger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassangerExists(passanger.Id))
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
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id", passanger.ReservationId);
            return View(passanger);
        }

        // GET: Passanger/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passanger = await _context.Passengers
                .Include(p => p.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passanger == null)
            {
                return NotFound();
            }

            return View(passanger);
        }

        // POST: Passanger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passengers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Passengers'  is null.");
            }
            var passanger = await _context.Passengers.FindAsync(id);
            if (passanger != null)
            {
                _context.Passengers.Remove(passanger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassangerExists(int id)
        {
            return (_context.Passengers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
