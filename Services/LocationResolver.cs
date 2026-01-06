namespace TouringChecker.Services
{
    public class LocationResolver
    {
        private readonly IGeocodingService _geocodingService;

        public LocationResolver(IGeocodingService geocodingService)
        {
            _geocodingService = geocodingService;
        }
    }
}
