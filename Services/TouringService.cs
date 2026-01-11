using System.ComponentModel.DataAnnotations;
using System.Collections;
using TouringChecker.Domain;
using TouringChecker.Dtos;

namespace TouringChecker.Services
{
    public class TouringService
    {
        private readonly LocationResolver _locationResolver;
        private readonly WeatherService _weatherService;

        public TouringService(
            LocationResolver locationResolver,
            WeatherService weatherService)
        {
            _locationResolver = locationResolver;
            _weatherService = weatherService;
        }

        /// <summary>
        /// ツーリング可否を判断する
        /// </summary>
        public async Task<TouringCheckResult> Check(TouringCheckRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.CurrentLocation == null &&
                request.Destination == null)
            {
                throw new ValidationException(
                    "現在地または目的地のどちらかを指定してください");
            }

            // 基準となるLocationsを決定
            IEnumerable<Location> locations =
                new[] { request.CurrentLocation, request.Destination }
                    .OfType<Location>();

            // Locationsを解決
            IEnumerable<ResolvedLocation> resolvedLocations =
                locations.Select(l=> _locationResolver.Resolve(l));

            // 中間地点を作る
            ResolvedLocation? middleLocation = null;
            if (resolvedLocations.Count() == 2)
            {
                var startLocation = resolvedLocations.First();
                var finishLocation = resolvedLocations.Last();

                middleLocation = new ResolvedLocation
                (
                    (startLocation.Latitude + finishLocation.Latitude) / 2,
                    (startLocation.Longitude + finishLocation.Longitude) / 2,
                    "Middle"
                );
            }

            var resolvedList = resolvedLocations.ToList();
            if(middleLocation != null)
            {
                resolvedList.Add(middleLocation);
            }

            // 天気取得
            var weathers = new List<WeatherTomorrowDto>();

            foreach(var resolved in resolvedList)
            {
                var weather = await _weatherService.GetTomorrowAsync(resolved);
                weathers.Add(weather);
            }

            return new TouringCheckResult
            {
                IsTouringRecommended = weathers.All(w => w.IsGoodForTouring)
            };
        }
    }
}
