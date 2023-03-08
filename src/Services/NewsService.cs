namespace CityInfo.Services
{
    public class NewsService
    {
        public const int IndexNewsCount = 3;
        public const int NewsCount = 10;
        public const int PopularNewsCount = 5;
        public const string SortByDate = "published_desc";
        public const string SortByPopularity = "popularity";

        private readonly AppConfig _config;
        private const string NewsUrl = "http://api.mediastack.com/v1/news?access_key={0}&country=us&keywords={1}&sort={2}&languages=en&limit=20";
        public NewsService(IOptions<AppConfig> config)
        {
            _config = config.Value;
        }

        public async Task<NewsModel> List(string city)
        {
            return RemoveDuplicates(
                await AppRequest<NewsModel>.Send(string.Format(NewsUrl, _config.NewsKey, city, SortByDate)),
                IndexNewsCount);
        }

        public async Task<NewsIndexModel> Index(string city, string category)
        {
            var categories = new List<string> {
            "General",
            "Business",
            "Entertainment",
            "Health",
            "Science",
            "Sports",
            "Technology"
            };

            var url = string.IsNullOrEmpty(category) ? NewsUrl : NewsUrl + $"&categories={category.ToLower()}";

            var news = RemoveDuplicates(
                await AppRequest<NewsModel>.Send(string.Format(url, _config.NewsKey, city, SortByDate))
                , NewsCount);

            var hotNews = RemoveDuplicates(
                await AppRequest<NewsModel>.Send(string.Format(NewsUrl, _config.NewsKey, city, SortByPopularity)),
                PopularNewsCount);

            return new NewsIndexModel { News = news, HotNews = hotNews, Categories = categories };
        }

        private NewsModel RemoveDuplicates(NewsModel model, int count)
        {
            if (model != null && model.Data.Any())
            {
                NewsDataModel obj = null;
                List<NewsDataModel> list = null;
                for (int i = 0; i < model.Data.Count; i++)
                {
                    obj = model.Data[i];
                    list = model.Data.Where(x => x.Title == obj.Title).ToList();
                    if (list.Count > 1)
                    {
                        for (int j = 0; j < list.Count - 1; j++)
                        {
                            model.Data.Remove(list[j]);
                        }
                    }
                }
            }

            model.Data = model.Data.Take(count).ToList();
            return model;
        }
    }
}