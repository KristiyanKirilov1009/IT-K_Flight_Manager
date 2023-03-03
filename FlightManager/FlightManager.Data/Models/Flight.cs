using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    public class Flight
    {
        public Flight()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public string LoacationFrom { get; set; }
        [Required]
        public string LoacationTo { get; set; }
        [Required]
        public DateTime TakeOffTime { get; set; }
        [Required]
        public DateTime LandingTime { get; set; }
        [Required]
        public string PlaneType { get; set; }
        [Required]
        public string PilotName { get; set; }
        [Required]
        public int PassengersCapacity { get; set; }
        [Required]
        public int CapacityBusinessClass { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
