using APIAggregator.Enums;
using APIAggregator.Models;

namespace APIAggregator.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherApiResponse> GetWeatherDetailsAsync(decimal latidute, decimal longitude, TemperatureUnit temperatureUnit);
    }
}
