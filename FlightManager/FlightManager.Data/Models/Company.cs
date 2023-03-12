using FlightManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class Company
    {
        public Company()
        {
            Users = new HashSet<User>();
            Fligths = new HashSet<Flight>();
        }

        [Key]
        public int CompanyID { get; set; }
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string CompanyLocation { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Flight> Fligths { get; set; }
    }
}
