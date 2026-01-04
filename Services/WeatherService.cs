using TouringChecker.Dtos;

namespace TouringChecker.Services
{
    public class WeatherService
    {
        public WeatherTomorrowDto GetTomorrow(string city)
        {
            return new WeatherTomorrowDto
            {
                City = city,
                Date = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"),
                Weather = "Sunny",
                Temperature = "7.0"
            };
        }
    }
}
