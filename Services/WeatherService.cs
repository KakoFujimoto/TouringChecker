using TouringChecker.Dtos;
using TouringChecker.Utils;

namespace TouringChecker.Services
{
    public class WeatherService
    {
        private readonly OpenWeatherService _openWeatherService;

        public WeatherService(OpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
        }

        public async Task<WeatherTomorrowDto> GetTomorrowAsync(string city)
        {
            var forecast =
                await _openWeatherService.GetForecastAsync(city);

            var tomorrow = DateTime.Today.AddDays(1);

            var tomorrowItems = forecast.List
                .Where(item =>
                    DateTimeUtils.FromUnixTimeSecondsToLocal(item.Dt).Date
                        == tomorrow.Date)
                .ToList();

            if (!tomorrowItems.Any())
            {
                throw new InvalidOperationException("明日の天気データが取得できませんでした");
            }

            var target = tomorrowItems
                .OrderBy(item =>
                    Math.Abs(
                        DateTimeUtils.FromUnixTimeSecondsToLocal(item.Dt).Hour - 12))
                .First();

            // 判定ルール
            const double MaxWindSpeed = 8.0;
            const double MaxRainProbability = 0.3;

            bool canRide = true;
            string? reason = null;

            if(target.Wind.Speed > MaxWindSpeed)
            {
                canRide = false;
                reason = $"風速が強すぎます({target.Wind.Speed})m/s)";
            }
            else if (target.Pop > MaxRainProbability)
            {
                canRide = false;
                reason = $"降水確率が高すぎます({(int)target.Pop * 100})%)";
            }

            return new WeatherTomorrowDto
            {
                City = city,
                Date = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"),
                Weather = target.Weather.First().Main,
                Temperature = target.Main.Temp,
                CanRide = canRide,
                Reason = reason
            };
        }
    }
}
