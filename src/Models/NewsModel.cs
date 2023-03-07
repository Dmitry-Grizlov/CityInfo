using Newtonsoft.Json;

namespace CityInfo.Models
{
    public class NewsModel
    {
        public List<NewsDataModel> Data { get; set; }
    }

    public class NewsDataModel
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        [JsonProperty("published_at")]
        public string PublishedAt { get; set; }

        public string PublicationDate => DateTime.Parse(PublishedAt).ToString("dd.MM");

        public string FormattedDescription => Description
            .Replace("&#8220;", "\"")
            .Replace("&#8221;", "\"")
            .Replace("&#8217;", "`");
    }
}