using CityInfo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsService _news;

        public NewsController(NewsService news)
        {
            _news = news;
        }

        public async Task<IActionResult> Index(string city, string category)
        {
            ViewBag.Title = city;
            var result = await _news.Index(city, category);
            return View(result);
        }
    }
}