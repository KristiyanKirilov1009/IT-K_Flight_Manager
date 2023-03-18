using FlightManager.Data.Models;
using FlightManager.Data.Models.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Models
{
    public class User
    {
        public User()
        {
            
        }
        public User(string userName, string password, string firstName, string lastName, string eGN, string address, string phoneNumber, string nationality)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            EGN = eGN;
            Address = address;
            PhoneNumber = phoneNumber;
            Nationality = nationality;
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(18, MinimumLength = 5, ErrorMessage = "Username should be at least 5 characters!")]
        public string UserName { get; set; }
        [Required]
        [StringLength(130, MinimumLength = 8, ErrorMessage = "Password should be at least 8 characters!")]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [StringLength(18, MinimumLength = 2, ErrorMessage = "First name should be at least 2 characters!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(18, MinimumLength = 2, ErrorMessage = "Last name should be at least 2 characters!")]
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
        [StringLength(57,MinimumLength = 3, ErrorMessage = "Nationality should be at least 3 characters!")]
        public string Nationality { get; set; }
        [Required]
        public Roles Role { get; set; }

        public int CompanyID { get; set; }

        [ForeignKey(nameof(CompanyID))]
        public CompaniesUsers Company { get; set; }

    }
}
