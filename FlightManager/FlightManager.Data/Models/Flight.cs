using FlightManager.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Models
{
    public class Flight
    {
        public Flight()
        {
            Reservations = new HashSet<Reservation>();
        }

        public Flight(string loacationFrom, string loacationTo, DateTime takeOffTime, DateTime landingTime, string planeType, string pilotName, int passengersCapacity, int capacityBusinessClass)
        {
            LoacationFrom = loacationFrom;
            LoacationTo = loacationTo;
            TakeOffTime = takeOffTime;
            LandingTime = landingTime;
            PlaneType = planeType;
            PilotName = pilotName;
            PassengersCapacity = passengersCapacity;
            CapacityBusinessClass = capacityBusinessClass;
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
        [ForeignKey(nameof(CompanyID))]
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
