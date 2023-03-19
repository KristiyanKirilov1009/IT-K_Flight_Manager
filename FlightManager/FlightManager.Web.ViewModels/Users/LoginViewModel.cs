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
        [MaxLength(130)]
        [StringLength(18, MinimumLength = 4, ErrorMessage = "Username should be at least 4 characters!")]
        public string UserName { get; set; }
        [Required]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "Password should be at least 8 characters!")]
        public string Password { get; set; }
        [Required]
        [StringLength(130,MinimumLength = 4, ErrorMessage = "Company name too short!")]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(130)]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "Password should be at least 8 characters!")]
        public string CompanyPassword { get; set; }
    }
}
