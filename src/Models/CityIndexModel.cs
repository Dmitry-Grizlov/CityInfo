namespace CityInfo.Models
{
    public class CityIndexModel
    {
        public string City { get; set; }

        public NewsModel News { get; set; }

        public WeatherModel Weather { get; set; }

        public ImageModel Images { get; set; }
    }
}