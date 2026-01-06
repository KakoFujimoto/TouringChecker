namespace TouringChecker.Domain
{
    /// <summary>
    /// 座標が確定した地点
    /// </summary>
    public sealed class ResolvedLocation
    {
        /// <summary>
        /// 緯度（-90 ～ 90）
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// 経度（-180 ～ 180）
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// 出発名としての都市名（任意）
        /// </summary>
        public string? CityName { get; }

        public ResolvedLocation(
            double latitude,
            double longitude,
            string? cityName = null)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(latitude),
                    "Latitude must be between -90 and 90.");
            }

            if (longitude < -180 || longitude > 180)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(longitude),
                    "Longitude must be between -180 and 180.");
            }

            Latitude = latitude;
            Longitude = longitude;
            CityName = cityName;
        }
    }
}
