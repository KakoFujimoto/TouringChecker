namespace TouringChecker.Dtos
{
    public class TouringCheckResult
    {
        public string? CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Weather { get; set; } = string.Empty;
        public bool IsTouringRecommended { get; set; }
    }
}
