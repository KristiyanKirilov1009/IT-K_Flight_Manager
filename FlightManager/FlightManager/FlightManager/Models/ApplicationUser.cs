using Microsoft.AspNetCore.Identity;

namespace FlightManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UCN { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }
    }
}
