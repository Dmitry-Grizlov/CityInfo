using Microsoft.AspNetCore.Mvc;
using CityInfo.Services;

namespace CityInfo.Controllers
{
    public class CitiesController : Controller
    {
        private readonly WeatherService _weather;
        private readonly NewsService _news;
        private readonly ImageService _images;
        private readonly GeoService _geo;

        public CitiesController(WeatherService weather, NewsService news, ImageService images, GeoService geo)
        {
            _weather = weather;
            _news = news;
            _images = images;
            _geo = geo;
        }

        public async Task<IActionResult> Index(string coordinates = null)
        {
            var weather = await _weather.GetWeather(coordinates, HttpContext.GetIpAddress());
            var city = weather.City;

            ViewData["Title"] = city;

            var news = await _news.List(city);
            var images = await _images.GetImages(city);
            var result = new CityIndexModel { City = city, News = news, Weather = weather, Images = images };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CitiesList(string input)
        {
            return Json(await _geo.List(input));
        }

        public async Task<IActionResult> Photos(string city)
        {
            var result = await _images.GetImages(city, false);
            return View(result);
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}