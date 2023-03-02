namespace FlightManager.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Nationality { get; set; }

        public string Role { get; set; }

    }
}
