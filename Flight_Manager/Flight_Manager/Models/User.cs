namespace Flight_Manager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? firstName { get; set; }
        public string? middleName { get; set; }
        public string? lastName { get; set; }
        //Personal Identity Number
        public string? pIN { get; set; }
        public string? address { get; set; }
        public int phoneNumber { get; set; }
        public string? nationality { get; set; }

        public string? access { get; set; }

    }
}
