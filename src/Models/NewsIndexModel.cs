namespace CityInfo.Models
{
    public class NewsIndexModel
    {
        public NewsModel News { get; set; }

        public NewsModel HotNews { get; set; }

        public List<string> Categories { get; set; }
    }
}