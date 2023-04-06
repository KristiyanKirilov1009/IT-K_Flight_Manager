using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    public class Flight
    {
        public Flight()
        {
            Reservations = new HashSet<Reservation>();
            FilledSeatsEconomy = 0;
            FilledSeatsBuisness = 0;
        }

        public int Id { get; set; }
        public string? LocationFrom { get; set; }
        public string? LocationTo { get; set; }
        public DateTime TakeOff { get; set; }

        [Required(ErrorMessage = "Landing date should be after take off date!")]
        public DateTime Landing { get; set; }
        public string PlaneType { get; set; }
        public string PlaneNumber { get; set; }
        public string PilotName { get; set; }

        public int FilledSeatsEconomy { get; set; }
        public int FilledSeatsBuisness { get; set; }
        public int PassangerCapacity { get; set; }
        public int BussinessClassCapacity { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
