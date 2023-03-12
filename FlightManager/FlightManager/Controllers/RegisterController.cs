using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
