namespace TouringChecker.Dtos
// 外部API用なのでいずれはディレクトリを分けるつもり
{
    public class OpenWeatherResponse
    {
        public List<OpenWeatherListItem> List { get; set; } = new();
    }

    public class OpenWeatherListItem
    {
        public long Dt { get; set; }
        public OpenWeatherMain Main { get; set; } = new();
        public List<OpenWeatherWeather> Weather { get; set; } = new();
        public OpenWeatherWind Wind { get; set; } = new();
        public double Pop { get; set; } = new();
    }

    public class OpenWeatherMain
    {
        public double Temp {  get; set; }
    }

    public class OpenWeatherWeather
    {
        public string Main { get; set; } = "";
        public string Description { get; set; } = string.Empty;
    }

    public class OpenWeatherWind
    {
        public double Speed { get; set; }
    }
}
