namespace CityInfo.Services
{
    public class GeoService
    {
        private const string GeoUrl = "https://geocoding-api.open-meteo.com/v1/search?name={0}";

        public GeoService()
        {

        }

        public async Task<GeoModel> List(string input)
        {
            var result = await AppRequest<GeoModel>.Send(string.Format(GeoUrl, input));
            return result;
        }
    }
}