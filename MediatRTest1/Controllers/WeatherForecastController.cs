using System.Collections.Generic;
using System.Collections.Immutable;
using MediatRTest1.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatRTest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService weatherForecastService;
        private readonly IWeatherForecastValidatorService weatherForecastValidatorService;
        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(
            IWeatherForecastService weatherForecastService,
            IWeatherForecastValidatorService weatherForecastValidatorService,
            ILogger<WeatherForecastController> logger)
        {
            this.weatherForecastService = weatherForecastService;
            this.weatherForecastValidatorService = weatherForecastValidatorService;
            this.logger = logger;
        }

        [HttpGet("{forecastDays}")]
        public IEnumerable<WeatherForecast> Get(int forecastDays)
        {
            var validationResult = weatherForecastValidatorService.Validate(forecastDays);

            var weatherForecasts = validationResult.Match(
                _ =>
                {
                    logger.LogInformation($"************************************************");
                    logger.LogInformation("Handling GetWeatherForecasts");
                    var forecasts = weatherForecastService.GetWeatherForecasts(forecastDays: forecastDays);
                    logger.LogInformation("Handled GetWeatherForecasts");
                    logger.LogInformation($"************************************************");
                    return forecasts;
                },
                err =>
                {
                    logger.Log(LogLevel.Error, err);
                    return ImmutableList<WeatherForecast>.Empty;
                });

            return weatherForecasts;
        }

        [HttpGet("historical/{region}")]
        public IEnumerable<WeatherForecast> GetHistoricalWeatherData(string region)
        {
            logger.LogInformation($"************************************************");
            logger.LogInformation("Handling GetHistoricalWeatherData");
            var historicalWeatherData = weatherForecastService.GetHistoricalWeatherData(region);
            logger.LogInformation("Handled GetHistoricalWeatherData");
            logger.LogInformation($"************************************************");

            return historicalWeatherData;
        }
    }
}
