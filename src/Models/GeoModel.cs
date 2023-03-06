namespace CityInfo.Models
{
    public class GeoModel
    {
        public List<GeoDataModel> Results { get; set; }
    }

    public class GeoDataModel
    {
        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string Country { get; set; }

        public string Admin1 { get; set; }
    }
}