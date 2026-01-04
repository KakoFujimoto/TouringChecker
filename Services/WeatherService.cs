using TouringChecker.Dtos;

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

            var first = forecast.List.First();

            return new WeatherTomorrowDto
            {
                City = city,
                Date = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"),
                Weather = first.Weather.First().Main,
                Temperature = first.Main.Temp
            };
        }
    }
}
