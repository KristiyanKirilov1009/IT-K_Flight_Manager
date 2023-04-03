﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FlightManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AutoMapper;

namespace FlightManager.Models
{
    public class Reservation
    {
        private ApplicationDbContext _context;
        public Reservation(ApplicationDbContext context)
        {
            _context = context;
        }
        public Reservation()
        {
            PassangerList = new HashSet<Passanger>();
            Flight = _context.Flights.Where(f => f.Id == FlightId).FirstOrDefault();
            CreatedAt = DateTime.Now;
            CompletedPassengers = 0;
        }

        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int FlightId { get; set; }
        public int Passengers { get; set; }
        public int CompletedPassengers { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        public ICollection<Passanger>? PassangerList { get; set; }
    }
}
