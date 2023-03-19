using FlightManager.Data.Models;
using FlightManager.Data.Models.Enums;
using FlightManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Web.ViewModels.Flights
{
    public class ReservationViewModel
    {
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
        public string PhoneNumber { get; set; }
        [Required]
        public string Nationality { get; set; }
        public TicketType TicketType { get; set; }
        public Flight Flight { get; set; }
        public ICollection<ReservationsPassangers> ReservationsPassangers { get; set; }
    }
}
