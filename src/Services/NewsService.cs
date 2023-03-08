namespace CityInfo.Services
{
    public class NewsService
    {
        private readonly AppConfig _config;
        private const string NewsUrl = "http://api.mediastack.com/v1/news?access_key={0}&country=us&keywords={1}&date={2}&sort=published_desc&language=us&limit=3";
        public NewsService(IOptions<AppConfig> config)
        {
            _config = config.Value;
        }

        public async Task<NewsModel> GetNews(string city)
        {
            var result = await AppRequest<NewsModel>.Send(string.Format(NewsUrl, _config.NewsKey, city, DateTime.Today.ToString("yyyy-MM-dd")));
            return result;
        }
    }
}