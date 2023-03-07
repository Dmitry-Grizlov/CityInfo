using Newtonsoft.Json;

namespace CityInfo.Models
{
    public class ImageModel
    {
        public List<ImageResultsModel> Results { get; set; }
    }

    public class ImageResultsModel
    {
        [JsonProperty("alt_description")]
        public string AltDescription { get; set; }

        public ImageUrlsModel Urls { get; set; }
    }

    public class ImageUrlsModel
    {
        public string Full { get; set; }

        public string Regular { get; set; }

        public string thumb { get; set; }
    }
}