using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Models
{
    public class Reservation
    {
        public Reservation()
        {
            Passangers = new HashSet<Passanger>();
        }


        [Key]
        public int ReservationID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(10)]
        public int EGN { get; set; }
        [Required]
        [MaxLength(10)]
        public int PhoneNumber { get; set; }
        [Required]
        public string Nationality { get; set; }
        public TicketTypes TicketType { get; set; }

        [ForeignKey(nameof(FlightID))]
        public int? FlightID { get; set; }
        public Flight Flight { get; set; }
        public ICollection<Passanger> Passangers { get; set; }
    }
}
