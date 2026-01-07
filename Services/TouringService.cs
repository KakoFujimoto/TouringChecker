using System.ComponentModel.DataAnnotations;
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

            // 基準となるLocationを決定
            var baseLocation =
                request.CurrentLocation ?? request.Destination;

            // Locationを解決
            ResolvedLocation resolvedLocation =
                _locationResolver.Resolve(baseLocation);

            // 天気取得
            WeatherTomorrowDto weather =
                await _weatherService.GetTomorrowAsync(resolvedLocation);

            return new TouringCheckResult
            {
                CityName = resolvedLocation.CityName,
                Latitude = resolvedLocation.Latitude,
                Longitude = resolvedLocation.Longitude,
                Weather = weather.Summary,
                IsTouringRecommended = weather.IsGoodForTouring
            };
        }
    }
}
