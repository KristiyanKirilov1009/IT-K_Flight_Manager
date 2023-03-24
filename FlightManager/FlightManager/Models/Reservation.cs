using Microsoft.AspNetCore.Authorization.Infrastructure;
using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Reservation
    {
        public Reservation()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int FlightId { get; set; }

        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        public ICollection<Passenger> Passengers { get; set; }
    }
}

