using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    public class Reservation
    {
        public Reservation()
        {
            Passangers = new HashSet<Passanger>();
        }

        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int FlightId { get; set; }

        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        public ICollection<Passanger> Passangers { get; set; }
    }
}
