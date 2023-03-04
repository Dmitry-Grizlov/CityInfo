using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    public class CitiesController : Controller
    {
        public CitiesController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Photos()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}