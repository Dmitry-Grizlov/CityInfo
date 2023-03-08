global using CityInfo.Extensions;
global using CityInfo.Models;
global using Newtonsoft.Json;
global using Microsoft.Extensions.Options;

namespace CityInfo.Services
{
    public static class Services
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services
                .AddScoped<WeatherService>()
                .AddScoped<NewsService>()
                .AddScoped<ImageService>()
                .AddScoped<GeoService>();
        }
    }
}