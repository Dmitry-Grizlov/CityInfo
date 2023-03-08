namespace CityInfo.Services
{
    public class ImageService
    {
        private readonly AppConfig _config;

        private const string ImagesUrl = "https://api.unsplash.com/search/photos/?client_id={0}&query={1},{1}-tourism,{1}-sightseeing,{1}-attractions&per_page=9&orientation=landscape";

        public ImageService(IOptions<AppConfig> config)
        {
            _config = config.Value;
        }

        public async Task<ImageModel> GetImages(string city)
        {
            var result = await AppRequest<ImageModel>.Send(string.Format(ImagesUrl, _config.ImageKey, city));
            return result;
        }
    }
}