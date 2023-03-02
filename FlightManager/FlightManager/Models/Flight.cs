namespace FlightManager.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string LoacationFrom { get; set; }
        public string LoacationTo { get; set; }
        public DateTime TakeOffTime { get; set; }
        public DateTime LandingTime { get; set; }
        public string PlaneType { get; set; }
        public string PlaneID { get; set; }
        public string PilotName { get; set; }
        public int PassengersCapacity { get; set; }
        public int CapacityBusinessClass { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
