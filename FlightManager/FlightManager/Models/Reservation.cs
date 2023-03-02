namespace FlightManager.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int EGN { get; set; }
        public int PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string TicketType { get; set; }

        public int FlightID { get; set; }
        public Flight Flight { get; set; }
        public List<Passanger>? Passangers { get; set; }
    }
}
