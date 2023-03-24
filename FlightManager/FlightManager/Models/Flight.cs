using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Flight
    {
        public Flight()
        {
            Reservations = new HashSet<Reservation>();
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
        public int PassangerCapacity { get; set; }
        public int BussinessClassCapacity { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
