namespace FlightManager.Models.ViewModels
{
    public class UserViewModel : ApplicationUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UCN { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }
    }
}
