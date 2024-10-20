using APIAggregator.Enums;
using APIAggregator.Interfaces;
using APIAggregator.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIAggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregationController : ControllerBase
    {
        private readonly IWordsService wordsService;
        private readonly IWeatherService weatherService;
        private readonly ISpotifyService spotifyService;
        private readonly ILogger<AggregationController> logger;

        public AggregationController(IWordsService wordsService, IWeatherService weatherService, ISpotifyService spotifyService,
            ILogger<AggregationController> logger)
        {
            this.wordsService = wordsService;
            this.weatherService = weatherService;
            this.spotifyService = spotifyService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAggregatedData(int? SporifySearchLimit,
            int? SpotifyNumberOfTopResults, string? SpotifySearchKeyword = null, MediaType MediaType = MediaType.multi,
            string? WordToAnalyze = null, decimal Latitude = 0, decimal Longitude = 0,
            TemperatureUnit TemperatureUnit = TemperatureUnit.metric)
        {
            try
            {
                WordApiResponse wordDetails;
                if (string.IsNullOrEmpty(WordToAnalyze))
                {
                    wordDetails = null;
                }
                else
                {
                    wordDetails = await wordsService.GetWordDetailsAsync(WordToAnalyze);
                }

                var weatherApiResponse = await weatherService.GetWeatherDetailsAsync(Latitude, Longitude, TemperatureUnit);

                SpotifyApiResponse spotifyApiResponse;
                if (string.IsNullOrEmpty(SpotifySearchKeyword))
                {
                    spotifyApiResponse = null;
                }
                else
                {
                    spotifyApiResponse = await spotifyService.GetSpotifyDetailsAsync(SpotifySearchKeyword, 0, SporifySearchLimit,
                        SpotifyNumberOfTopResults, MediaType);
                }

                var aggregationResponse = new AggregatedResponse
                {
                    WordDetails = wordDetails,
                    WeatherDetails = weatherApiResponse,
                    SpotifyDetails = spotifyApiResponse,
                };

                return Ok(aggregationResponse);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in the aggregator controller.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the aggregated data.");
            }
        }
    }
}
