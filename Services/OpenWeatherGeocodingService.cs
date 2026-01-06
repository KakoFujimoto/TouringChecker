using TouringChecker.Domain;

namespace TouringChecker.Services
{
    public class OpenWeatherGeocodingService : IGeocodingService
    {
        private readonly HttpClient _httpClinet;
        private readonly string _apiKey;


        public OpenWeatherGeocodingService(
            HttpClient httpClinet,
            IConfiguration configuration)
        {
            _httpClinet = httpClinet;
            _apiKey = configuration["OpenWeather:ApiKey"]
                        ?? throw new InvalidOperationException("API key not found"); 
        }

        public ResolveLocation GetByCityName(string cityName)
        {
            var url =
               $"https://api.openweathermap.org/geo/1.0/direct" +
                $"?q={Uri.EscapeDataString(cityName)}" +
                $"&limit=1" +
                $"&appid={_apiKey}";

            var response = _httpClinet
                .GetFromJsonAsync<GeocodingResponse[]>(url)
                .GetAwaiter()
                .GetResult();

            if(response == null || response.Length == 0)
            {
                throw new ArgumentException(
                    $"City not found : {cityName}");
            }

            var geo = response[0];

            return new ResolveLocation(
                geo.Lat,
                geo.Lon,
                geo.Name
            );

        }

        private class GeocodingResponse
        {
            public string Name { get; set; } = default!;
            public double Lat { get; set; }
            public double Lon { get; set; }
            public string? Country { get; set; }
            public string? State { get; set; }
        }

    }
}
