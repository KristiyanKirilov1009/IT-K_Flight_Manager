using FlightManager.Services.Interfaces;
using FlightManager.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _user;

        public RegisterController(IUserService user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel user)
        {
            if(ModelState.IsValid)
            {
                if(!(_user.Exist(user.UserName)))
                {
                    _user.Create(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
                
            }
            return View(user);
        }
    }
}
