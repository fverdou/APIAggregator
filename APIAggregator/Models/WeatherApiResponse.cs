using Newtonsoft.Json;

namespace APIAggregator.Models
{
    public class WeatherApiResponse
    {
        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("data")]
        public List<DataItem> Data { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("state_code")]
        public string StateCode { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }

    public class DataItem
    {
        [JsonProperty("precip")]
        public long Precip { get; set; }

        [JsonProperty("snow")]
        public long Snow { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("timestamp_local")]
        public DateTimeOffset TimestampLocal { get; set; }

        [JsonProperty("timestamp_utc")]
        public DateTimeOffset TimestampUtc { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}
