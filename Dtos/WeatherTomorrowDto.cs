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

        // 現状は、通しでの実装 > 技術的負債との理念で進めている
        // 判定ロジックはDomain層が持つべき
        public static WeatherTomorrowDto From(
            OpenWeatherResponse response)
        {
            var tomorrow = response.List.First();

            // 判定基準が文字列ベースで弱い/雹など類似事案に対応できない
            return new WeatherTomorrowDto
            {
                Summary = tomorrow.Weather[0].Description,
                IsGoodForTouring = tomorrow.Weather[0].Main != "Rain"
            };
        }
    }
}
