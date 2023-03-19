using FlightManager.Data.Models;
using FlightManager.Data.Models.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Models
{
    public class Reservation
    {
        public Reservation()
        {
            ReservationsPassangers = new HashSet<ReservationsPassangers>();
        }

        public Reservation(string firstName, string middleName, string lastName, int eGN, int phoneNumber, string nationality, TicketType ticketType)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            EGN = eGN;
            PhoneNumber = phoneNumber;
            Nationality = nationality;
            TicketType = ticketType;
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
        public TicketType TicketType { get; set; }

        [ForeignKey(nameof(FlightID))]
        public int? FlightID { get; set; }
        public Flight Flight { get; set; }
        public ICollection<ReservationsPassangers> ReservationsPassangers { get; set; }
    }
}
