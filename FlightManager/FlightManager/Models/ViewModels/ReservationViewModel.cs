using FlightManager.Data;
using MimeKit.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Models.ViewModels
{
    public class ReservationViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(1, 10,ErrorMessage = "Reservation must contain between 1 and 10 passengers!")]
        public int Passengers { get; set; }
        [Required(ErrorMessage = "Must select a Flight!")]
        public int FlightId { get; set; }

        public ICollection<Passanger>? PassangerList { get; set; }
    }
}
