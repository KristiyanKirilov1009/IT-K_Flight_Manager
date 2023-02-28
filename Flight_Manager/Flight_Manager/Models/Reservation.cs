using Microsoft.EntityFrameworkCore.Storage;

namespace Flight_Manager.Models
{
    public class Reservation
    {
        public User creator { get; set; }
        public string creatorType { get; set; }
        public List<TempUser> tempUsers { get; set; }
        public string email { get; set; }
    }
}
