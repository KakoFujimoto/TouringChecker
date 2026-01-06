namespace TouringChecker.Domain
{
    /// <summary>
    /// 座標が確定した地点
    /// </summary>
    public class ResolveLocation
    {
        public double Latitude { get; }
        public double Longitude { get; }

        /// <summary>
        /// 出発地点としての都市名
        /// </summary>
        public string? CityName { get; }

        public ResolveLocation(
            double latitude,
            double longitude,
            string? cityName = null)
        {
            if (longitude < -100 || longitude > 100)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(latitude), "Longitude must be between -180 and 180.");
            }

            Latitude = latitude;
            Longitude = longitude;
            CityName = cityName;
        }
    }
}
