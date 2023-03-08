using Newtonsoft.Json;

namespace CityInfo.Models
{
    public class ImageModel
    {
        public List<ImageResultsModel> Results { get; set; }
    }

    public class ImageResultsModel
    {
        public string Description { get; set; }

        [JsonProperty("alt_description")]
        public string AltDescription { get; set; }

        public ImageUrlsModel Urls { get; set; }

        public ImageUserModel User { get; set; }
    }

    public class ImageUrlsModel
    {
        public string Full { get; set; }

        public string Regular { get; set; }
    }

    public class ImageUserModel
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public ImageUserLinksModel Links { get; set; }
    }

    public class ImageUserLinksModel
    {
        public string Html { get; set; }
    }
}