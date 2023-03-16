using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Web.ViewModels.Users
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        [Required]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "Password should be at least 8 characters!")]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [StringLength(18, MinimumLength = 3, ErrorMessage = "First name should be at least 3 characters!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(18, MinimumLength = 3, ErrorMessage = "Last name should be at least 3 characters!")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "EGN should be at least 10 characters!")]
        public string EGN { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Address is not valid!")]
        public string Address { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Phone number should be at least 10 characters!")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(57, MinimumLength = 1, ErrorMessage = "Nationality should be at least 10 characters!")]
        public string Nationality { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name should be at least 3 characters!")]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(130)]
        public string CompanyPassword { get; set; }
    }
}
