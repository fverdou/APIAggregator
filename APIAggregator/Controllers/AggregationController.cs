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
        public async Task<IActionResult> GetAggregatedData(string searchQuery, int? offset, int? limit,
            int? numberOfTopResults, MediaType type = MediaType.multi, string ? word = null, decimal latitude = 0, decimal longitude = 0,
            TemperatureUnit temperatureUnit = TemperatureUnit.metric)
        {
            try
            {
                WordApiResponse wordDetails;
                if (string.IsNullOrEmpty(word))
                {
                    wordDetails = null;
                }
                else
                {
                    wordDetails = await wordsService.GetWordDetailsAsync(word);
                }

                var weatherApiResponse = await weatherService.GetWeatherDetailsAsync(latitude, longitude, temperatureUnit);

                var spotifyApiResponse = await spotifyService.GetSpotifyDetailsAsync(searchQuery, offset, limit, numberOfTopResults, type);

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
