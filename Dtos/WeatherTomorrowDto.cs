namespace TouringChecker.Dtos
{
    public class WeatherTomorrowDto
    {
        public string City { get; set; } = "";
        public string Date { get; set; } = "";
        public string Weather { get; set; } = "";
        public double Temperature { get; set; } = 0;
        public bool CanRide { get; set; }
        public string? Reason { get; set; }
        public string Summary { get; set; } = string.Empty;
        public bool IsGoodForTouring { get; set; }

        public static WeatherTomorrowDto From(
            OpenWeatherResponse response)
        {
            var tomorrow = response.List.First();

            return new WeatherTomorrowDto
            {
                Summary = tomorrow.Weather[0].Description,
                IsGoodForTouring = tomorrow.Weather[0].Main != "Rain"
            };
        }
    }
}
