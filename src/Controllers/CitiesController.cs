using Newtonsoft.Json;
using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CityInfo.Extensions;

namespace CityInfo.Controllers
{
    public class CitiesController : Controller
    {
        private readonly AppConfig _config;

        public CitiesController(IOptions<AppConfig> config)
        {
            _config = config.Value;
        }

        public async Task<IActionResult> Index(string coordinates = null)
        {
            var request = new AppRequest();
            var geoUrl = string.Empty;
            var city = string.Empty;
            if (string.IsNullOrEmpty(coordinates))
            {
                var ip = "71.9.37.133";// HttpContext.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                var url = $"https://api.ipgeolocation.io/ipgeo?apiKey={_config.IpGeoKey}&ip={ip}";
                var locationData = JsonConvert.DeserializeObject<GeoIpModel>(await request.Get(url));
                geoUrl = $"https://api.open-meteo.com/v1/forecast?latitude={locationData.Latitude}&longitude={locationData.Longitude}&current_weather=true&daily=temperature_2m_max,temperature_2m_min,weathercode&timezone=PST&temperature_unit=celsius";
                city = locationData.StateProv;
            }
            else
            {
                var data = coordinates.Split('|');
                geoUrl = $"https://api.open-meteo.com/v1/forecast?latitude={data[1]}&longitude={data[2]}&current_weather=true&daily=temperature_2m_max,temperature_2m_min,weathercode&timezone=PST&temperature_unit=celsius";
                city = data[0];
            }
            var result = JsonConvert.DeserializeObject<WeatherModel>(await request.Get(geoUrl));

            result.City = city;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CitiesList(string input)
        {
            var url = $"https://geocoding-api.open-meteo.com/v1/search?name={input}";
            var request = new AppRequest();

            var response = await request.Get(url);
            return Json(JsonConvert.DeserializeObject<GeoModel>(response));
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