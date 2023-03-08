namespace CityInfo.Services
{
    public class ImageService
    {
        private readonly AppConfig _config;

        public const int IndexPerPage = 9;
        public const int PhotosPerPage = 12;

        private const string ImagesUrl = "https://api.unsplash.com/search/photos/?client_id={0}&query={1},{1}-tourism,{1}-sightseeing,{1}-attractions&per_page={2}&orientation=landscape";

        public ImageService(IOptions<AppConfig> config)
        {
            _config = config.Value;
        }

        public async Task<ImageModel> GetImages(string city, bool index = true)
        {
            var result = await AppRequest<ImageModel>.Send(string.Format(ImagesUrl, _config.ImageKey, city, index ? IndexPerPage : PhotosPerPage));
            return result;
        }
    }
}