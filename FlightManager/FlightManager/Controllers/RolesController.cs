using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Controllers {
    public class RolesController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Admin() {
            return View();
        }

        public IActionResult Employee() {
            return View();
        }
    }
}
