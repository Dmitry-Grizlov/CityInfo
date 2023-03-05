using Newtonsoft.Json;
using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CityInfo.Extensions;

namespace CityInfo.Controllers
{
    public class CitiesController : Controller
    {
        public CitiesController() { }

        public async Task<IActionResult> Index()
        {
            var lat = "34.146361";
            var lon = "-118.248235";
            var request = new AppRequest();

            var osurl = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true&daily=temperature_2m_max,temperature_2m_min,weathercode&timezone=PST&temperature_unit=celsius";
            var result = JsonConvert.DeserializeObject<WeatherModel>(await request.Get(osurl));

            return View(result);
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