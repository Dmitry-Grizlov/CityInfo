using Newtonsoft.Json;

namespace CityInfo.Models
{
    public class GeoIpModel
    {
        [JsonProperty("state_prov")]
        public string StateProv { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public GeoIpModel() { }

        public GeoIpModel(string stateProv, decimal lat, decimal lon)
        {
            StateProv = stateProv;
            Latitude = lat;
            Longitude = lon;
        }

        public GeoIpModel(string stateProv, string lat, string lon)
        {
            StateProv = stateProv;
            Latitude = decimal.Parse(lat);
            Longitude = decimal.Parse(lon);
        }
    }
}