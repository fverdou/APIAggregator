using APIAggregator.Enums;
using APIAggregator.Interfaces;
using APIAggregator.Models;
using Newtonsoft.Json;
using System.Web;

namespace APIAggregator.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(HttpClient httpClient, IConfiguration configuration, ILogger<WeatherService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<WeatherApiResponse> GetWeatherDetailsAsync(decimal latidute, decimal longitude, TemperatureUnit temperatureUnit)
        {
            try
            {
                var url = $"{_configuration["RapidAPI:WeatherAPIUri"]}";

                var uriBuilder = new UriBuilder(url);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["lat"] = latidute.ToString();
                query["lon"] = longitude.ToString();
                query["units"] = temperatureUnit.ToString();
                uriBuilder.Query = query.ToString();

                _httpClient.DefaultRequestHeaders.Add(_configuration["RapidAPI:ApiKeyName"], _configuration["RapidAPI:ApiKeyValue"]);
                var response = await _httpClient.GetAsync(uriBuilder.ToString());
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var weatherDetails = JsonConvert.DeserializeObject<WeatherApiResponse>(jsonResponse);
                return weatherDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
