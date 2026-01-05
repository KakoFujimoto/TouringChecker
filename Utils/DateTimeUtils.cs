namespace TouringChecker.Utils
{
    public static class DateTimeUtils
    {
        public static DateTime FromUnixTimeSecondsToLocal(long dt)
        {
            return DateTimeOffset
                .FromUnixTimeSeconds(dt)
                .LocalDateTime;
        }
    }
}
