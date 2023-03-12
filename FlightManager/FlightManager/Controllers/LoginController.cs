using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
