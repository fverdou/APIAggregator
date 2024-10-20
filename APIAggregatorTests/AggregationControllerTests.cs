using APIAggregator.Controllers;
using APIAggregator.Enums;
using APIAggregator.Interfaces;
using APIAggregator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace APIAggregatorTests
{
    public class AggregationControllerTests
    {
        [Fact]
        public async Task AllServicesReturnValidResponsesTest()
        {
            var loggerService = new Mock<ILogger<AggregationController>>();
            var spotifyService = new Mock<ISpotifyService>();
            var weatherService = new Mock<IWeatherService>();
            var wordsService = new Mock<IWordsService>();

            var aggregationController = new AggregationController(wordsService.Object, weatherService.Object, spotifyService.Object, loggerService.Object);

            var spotifyResponse = new SpotifyApiResponse
            {
                Albums = new Albums
                {
                    TotalCount = 1,
                },
            };
            var weatherResponse = new WeatherApiResponse
            {
                CityName = "Athens",
            };
            var wordsResponse = new WordApiResponse
            {
                Word = "example",
            };

            var apiResponse = new AggregatedResponse
            {
                SpotifyDetails = spotifyResponse,
                WeatherDetails = weatherResponse,
                WordDetails = wordsResponse
            };

            spotifyService.Setup(x => x.GetSpotifyDetailsAsync(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(),
                It.IsAny<MediaType>())).Returns(Task.FromResult(spotifyResponse));
            weatherService.Setup(x => x.GetWeatherDetailsAsync(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<TemperatureUnit>()))
                .Returns(Task.FromResult(weatherResponse));
            wordsService.Setup(x => x.GetWordDetailsAsync(It.IsAny<string>())).Returns(Task.FromResult(wordsResponse));

            var result = await aggregationController.GetAggregatedData(It.IsAny<int?>(), It.IsAny<int?>(), "test",
                It.IsAny<MediaType>(), "test", It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<TemperatureUnit>());

            var okResult = Assert.IsType<OkObjectResult>(result);

            var actualResponse = Assert.IsType<AggregatedResponse>(okResult.Value);
            Assert.Equal(apiResponse.SpotifyDetails.Albums.TotalCount, actualResponse.SpotifyDetails.Albums.TotalCount);
            Assert.Equal(apiResponse.WeatherDetails.CityName, actualResponse.WeatherDetails.CityName);
            Assert.Equal(apiResponse.WordDetails.Word, actualResponse.WordDetails.Word);
        }

        [Fact]
        public async Task CallingWordAndSpotifyServiceWithoutParameterReturnsNullTest()
        {
            var loggerService = new Mock<ILogger<AggregationController>>();
            var spotifyService = new Mock<ISpotifyService>();
            var weatherService = new Mock<IWeatherService>();
            var wordsService = new Mock<IWordsService>();

            var aggregationController = new AggregationController(wordsService.Object, weatherService.Object, spotifyService.Object, loggerService.Object);

            var spotifyResponse = new SpotifyApiResponse
            {
                Albums = new Albums
                {
                    TotalCount = 1,
                },
            };
            var wordsResponse = new WordApiResponse
            {
                Word = "example",
            };

            var apiResponse = new AggregatedResponse
            {
                WordDetails = wordsResponse
            };

            spotifyService.Setup(x => x.GetSpotifyDetailsAsync(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(),
                It.IsAny<MediaType>())).Returns(Task.FromResult(spotifyResponse));
            wordsService.Setup(x => x.GetWordDetailsAsync(It.IsAny<string>())).Returns(Task.FromResult(wordsResponse));

            var result = await aggregationController.GetAggregatedData(It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<string>(),
                It.IsAny<MediaType>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<TemperatureUnit>());

            var okResult = Assert.IsType<OkObjectResult>(result);

            var actualResponse = Assert.IsType<AggregatedResponse>(okResult.Value);;
            Assert.Null(actualResponse.WordDetails);
            Assert.Null(actualResponse.SpotifyDetails);
        }

        [Fact]
        public async Task ExceptionGettingHandledTest()
        {
            var loggerService = new Mock<ILogger<AggregationController>>();
            var spotifyService = new Mock<ISpotifyService>();
            var weatherService = new Mock<IWeatherService>();
            var wordsService = new Mock<IWordsService>();

            var aggregationController = new AggregationController(wordsService.Object, weatherService.Object, spotifyService.Object, loggerService.Object);
            wordsService.Setup(x => x.GetWordDetailsAsync(It.IsAny<string>())).ThrowsAsync(new Exception()); ;

            var result = await aggregationController.GetAggregatedData(It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<string>(),
                It.IsAny<MediaType>(), "test", It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<TemperatureUnit>());

            var errorResult = Assert.IsType<ObjectResult>(result);
            var actualResponse = Assert.IsType<string>(errorResult.Value);
            Assert.Equal("An error occurred while fetching the aggregated data.", actualResponse);
        }

        [Fact]
        public async Task AllServicesFailToReturnValidResponcesTest()
        {
            var loggerService = new Mock<ILogger<AggregationController>>();
            var spotifyService = new Mock<ISpotifyService>();
            var weatherService = new Mock<IWeatherService>();
            var wordsService = new Mock<IWordsService>();

            var aggregationController = new AggregationController(wordsService.Object, weatherService.Object, spotifyService.Object, loggerService.Object);

            spotifyService.Setup(x => x.GetSpotifyDetailsAsync(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(),
                It.IsAny<MediaType>())).Returns((Task.FromResult((SpotifyApiResponse)null)));
            weatherService.Setup(x => x.GetWeatherDetailsAsync(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<TemperatureUnit>()))
                .Returns(Task.FromResult((WeatherApiResponse)null));
            wordsService.Setup(x => x.GetWordDetailsAsync(It.IsAny<string>())).Returns(Task.FromResult((WordApiResponse)null));

            var result = await aggregationController.GetAggregatedData(It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<string>(),
                It.IsAny<MediaType>(), "test", It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<TemperatureUnit>());

            var okResult = Assert.IsType<OkObjectResult>(result);

            var actualResponse = Assert.IsType<AggregatedResponse>(okResult.Value);
            Assert.Null(actualResponse.SpotifyDetails);
            Assert.Null(actualResponse.WeatherDetails);
            Assert.Null(actualResponse.WordDetails);
        }
    }
}