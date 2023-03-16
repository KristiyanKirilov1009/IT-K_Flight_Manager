using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Web.ViewModels.Companies
{
    public class CreateCompanyViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name should be at least 3 characters!")]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "Name should be at least 8 characters!")]
        public string Password { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Location should be at least 10 characters!")]
        public string CompanyLocation { get; set; }
    }
}
