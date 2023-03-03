using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Models
{
    public class Passanger
    {
        [Key]
        public int PassangerID { get; set; }
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
        [Required]
        public TicketTypes TicketType { get; set; }
        [ForeignKey(nameof(ReservationID))]
        public int? ReservationID { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
