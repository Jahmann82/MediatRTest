using System.Collections.Immutable;
using MediatR;
using MediatRTest1.Contracts;

namespace MediatRTest1.WeatherForecasts.RequestModels.QueryRequestModels
{
    public class GetWeatherForecastQuery : IRequest<IImmutableList<WeatherForecast>>
    {
        public GetWeatherForecastQuery(int forecastDays)
        {
            ForecastDays = forecastDays;
        }
        
        public int ForecastDays { get; }
    }
}