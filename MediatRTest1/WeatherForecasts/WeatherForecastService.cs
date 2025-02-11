using System;
using System.Collections.Immutable;
using System.Linq;
using MediatRTest1.Contracts;

namespace MediatRTest1.WeatherForecasts
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] Regions =
        {
            "North", "South", "East", "West", "Central"
        };

        public IImmutableList<WeatherForecast> GetWeatherForecasts(int forecastDays = 5)
        {
            var random = new Random();
            return Enumerable.Range(1, forecastDays)
                .Select(index => CreateWeatherForecast(index, random))
                .ToImmutableList();
        }

        public IImmutableList<WeatherForecast> GetHistoricalWeatherData(string region)
        {
            var random = new Random();
            return Enumerable.Range(1, 365)
                .Select(index => CreateHistoricalWeatherForecast(index, random, region))
                .ToImmutableList();
        }

        private static WeatherForecast CreateWeatherForecast(int index, Random random)
        {
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = random.Next(-20, 55),
                Summary = Summaries[random.Next(Summaries.Length)],
                WindSpeed = random.NextDouble() * 20,
                Region = Regions[random.Next(Regions.Length)]
            };
        }

        private static WeatherForecast CreateHistoricalWeatherForecast(int index, Random random, string region)
        {
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(-index),
                TemperatureC = random.Next(-20, 55),
                Summary = Summaries[random.Next(Summaries.Length)],
                WindSpeed = random.NextDouble() * 20,
                Region = region
            };
        }
    }
}
