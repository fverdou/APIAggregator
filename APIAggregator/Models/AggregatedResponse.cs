namespace APIAggregator.Models
{
    public class AggregatedResponse
    {
        public WordApiResponse? WordDetails { get; set; }
        public WeatherApiResponse? WeatherDetails { get; set; }
        public SpotifyApiResponse? SpotifyDetails { get; set; }
    }
}
