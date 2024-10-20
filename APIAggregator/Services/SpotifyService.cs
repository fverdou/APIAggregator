using APIAggregator.Enums;
using APIAggregator.Interfaces;
using APIAggregator.Models;
using Newtonsoft.Json;
using System.Web;

namespace APIAggregator.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SpotifyService> _logger;

        public SpotifyService(HttpClient httpClient, IConfiguration configuration, ILogger<SpotifyService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<SpotifyApiResponse> GetSpotifyDetailsAsync(string searchQuery, int? offset, int? limit, int? numberOfTopResults, MediaType type = MediaType.multi)
        {
            try
            {
                var url = $"{_configuration["RapidAPI:SpotifyAPIUri"]}";

                var uriBuilder = new UriBuilder(url);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["q"] = searchQuery;
                query["type"] = type.ToString();
                query["offset"] = offset.ToString();
                query["limit"] = limit.ToString();
                query["numberOfTopResults"] = numberOfTopResults.ToString();
                uriBuilder.Query = query.ToString();

                _httpClient.DefaultRequestHeaders.Add(_configuration["RapidAPI:ApiKeyName"], _configuration["RapidAPI:ApiKeyValue"]);
                var response = await _httpClient.GetAsync(uriBuilder.ToString());
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var spotifyDetails = JsonConvert.DeserializeObject<SpotifyApiResponse>(jsonResponse);
                return spotifyDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
