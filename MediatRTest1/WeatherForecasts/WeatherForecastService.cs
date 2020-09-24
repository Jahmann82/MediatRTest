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
        
        public IImmutableList<WeatherForecast> GetWeatherForecasts(int forecastDays = 5)
        {
            var random = new Random();
            return Enumerable.Range(1, forecastDays)
                .Select(index => CreateWeatherForecast(index, random))
                .ToImmutableList();
        }

        private static WeatherForecast CreateWeatherForecast(int index, Random random)
        {
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = random.Next(-20, 55),
                Summary = Summaries[random.Next(Summaries.Length)]
            };
        }
    }
}