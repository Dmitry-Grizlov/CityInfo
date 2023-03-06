using Newtonsoft.Json;

namespace CityInfo.Models
{
    public class GeoIpModel
    {
        [JsonProperty("state_prov")]
        public string StateProv { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}