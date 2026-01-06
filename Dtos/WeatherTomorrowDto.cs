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
    }
}
