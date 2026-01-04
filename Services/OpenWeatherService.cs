using System.Net.Http;
using TouringChecker.Dtos;


namespace TouringChecker.Services
{
    public class OpenWeatherService
    {
        private readonly HttpClient _httpClient;

        public OpenWeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<OpenWeatherResponse> GetForecastAsync(string city)
        {
            throw new NotImplementedException();
        }
    }
}
