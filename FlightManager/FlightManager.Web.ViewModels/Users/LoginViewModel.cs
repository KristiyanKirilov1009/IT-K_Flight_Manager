using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Web.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(18, MinimumLength = 5, ErrorMessage = "Username should be at least 5 characters!")]
        public string UserName { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "Password should be at least 8 characters!")]
        public string Password { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name should be at least 3 characters!")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(130)]
        public string CompanyPassword { get; set; }
    }
}
