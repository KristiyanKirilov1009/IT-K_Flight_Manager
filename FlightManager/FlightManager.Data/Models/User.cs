using FlightManager.Data.Models;
using FlightManager.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Models
{
    public class User
    {
        public User(string userName, string password, string firstName, string lastName, string eGN, string address, string phoneNumber, string nationality, Roles role)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            EGN = eGN;
            Address = address;
            PhoneNumber = phoneNumber;
            Nationality = nationality;
            Role = role;
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(10)]
        public string EGN { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public Roles Role { get; set; }

        [ForeignKey(nameof(CompanyID))]
        public int CompanyID { get; set; }
        public Company Company { get; set; }

    }
}
