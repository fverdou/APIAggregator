using APIAggregator.Interfaces;
using APIAggregator.Models;
using Newtonsoft.Json;

namespace APIAggregator.Services
{
    public class WordsService : IWordsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WordsService> _logger;

        public WordsService(HttpClient httpClient, IConfiguration configuration, ILogger<WordsService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<WordApiResponse> GetWordDetailsAsync(string word)
        {
            try
            {
                var url = $"{_configuration["RapidAPI:WordsAPIUri"]}{word}";
                _httpClient.DefaultRequestHeaders.Add(_configuration["RapidAPI:ApiKeyName"], _configuration["RapidAPI:ApiKeyValue"]);
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var wordDetails = JsonConvert.DeserializeObject<WordApiResponse>(jsonResponse);
                return wordDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
