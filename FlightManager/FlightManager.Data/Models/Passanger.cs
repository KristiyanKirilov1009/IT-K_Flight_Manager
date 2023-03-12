using FlightManager.Data.Models;
using FlightManager.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Models
{
    public class Passanger
    {
        public Passanger(string firstName, string middleName, string lastName, string eGN, string phoneNumber, string nationality, TicketTypes ticketType)
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
        public int PassangerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(10)]
        public string EGN { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public TicketTypes TicketType { get; set; }
        [ForeignKey(nameof(ReservationID))]
        public int ReservationID { get; set; }
        public Reservation? Reservation { get; set; }
        public ICollection<ReservationsPassangers> ReservationsPassangers { get; set; }
    }
}
