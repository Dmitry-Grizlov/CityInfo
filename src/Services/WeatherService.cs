namespace CityInfo.Services
{
    public class WeatherService
    {
        private readonly AppConfig _config;
        private readonly IHostEnvironment _env;
        private const string ForecastUrl = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current_weather=true&daily=temperature_2m_max,temperature_2m_min,weathercode&timezone=PST&temperature_unit=celsius";
        private const string IpGeolocationUrl = "https://api.ipgeolocation.io/ipgeo?apiKey={0}&ip={1}";
        public WeatherService(IOptions<AppConfig> config, IHostEnvironment env)
        {
            _config = config.Value;
            _env = env;
        }

        public async Task<WeatherModel> GetWeather(string coordinates, string ip)
        {
            GeoIpModel geoModel = null;
            if (string.IsNullOrEmpty(coordinates))
            {
                if (_env.EnvironmentName.ToLower() == "development")
                    ip = "71.9.37.133";

                geoModel = await AppRequest<GeoIpModel>.Send(string.Format(IpGeolocationUrl, _config.IpGeoKey, ip));
            }
            else
            {
                var data = coordinates.Split('|');
                geoModel = new(data[0], data[1], data[2]);
            }

            var result = await AppRequest<WeatherModel>.Send(string.Format(ForecastUrl, geoModel.Latitude, geoModel.Longitude));
            result.City = geoModel.StateProv;
            return result;
        }
    }
}