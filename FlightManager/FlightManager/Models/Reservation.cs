using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Reservation
    {
        public Reservation()
        {
            Passangers = new HashSet<Passenger>();
        }

        public int Id { get; set; }
        public int FlightId { get; set; }

        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        public ICollection<Passenger> Passangers { get; set; }
    }
}

