using System.ComponentModel.DataAnnotations;
using TouringChecker.Services;

namespace TouringChecker.Domain
{
    public class LocationResolver
    {
        private readonly IGeocodingService _geocodingService;

        public LocationResolver(IGeocodingService geocodingService)
        {
            _geocodingService = geocodingService;
        }

        public ResolvedLocation Resolve(Location location)
        {
            if(location.Latitude.HasValue &&
                location.Longitude.HasValue)
            {
                return new ResolvedLocation(
                    location.Latitude.Value,
                    location.Longitude.Value,
                    location.CityName
                );
            }

            if(!string.IsNullOrEmpty(location.CityName))
            {
                return _geocodingService
                    .GetByCityName(location.CityName);
            }

            throw new ValidationException(
                "Locationの指定が不正です");
        }
    }
}
