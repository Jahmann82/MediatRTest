using System.Collections.Immutable;

namespace MediatRTest1.Contracts
{
    public interface IWeatherForecastService
    {
        IImmutableList<WeatherForecast> GetWeatherForecasts(int forecastDays);
        IImmutableList<WeatherForecast> GetHistoricalWeatherData(string region);
    }
}
