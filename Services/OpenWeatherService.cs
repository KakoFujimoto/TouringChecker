using System.Net.Http;
using TouringChecker.Dtos;


namespace TouringChecker.Services
{
    public class OpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OpenWeatherService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<OpenWeatherResponse> GetForecastAsync(string city)
        {
            var apiKey = _configuration["OpenWeather:ApiKey"];

            var url =
                $"https://api.openweathermap.org/data/2.5/forecast" +
                $"?q={city}&appid={apiKey}&units=metric";

            var response =
                await _httpClient.GetFromJsonAsync<OpenWeatherResponse>(url);

            return response!;
        }
    }
}
