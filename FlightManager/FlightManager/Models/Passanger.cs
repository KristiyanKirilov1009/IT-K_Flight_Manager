using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Models
{
    public class Passanger
    {
        public int Id { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UCN { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public TicketType TicketType { get; set; }

        public int ReservationId { get; set; }

        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }
    }
}
