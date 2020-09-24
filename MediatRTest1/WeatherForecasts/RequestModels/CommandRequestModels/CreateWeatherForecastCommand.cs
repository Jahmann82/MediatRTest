using MediatR;
using MediatRTest1.Contracts;

namespace MediatRTest1.WeatherForecasts.RequestModels.CommandRequestModels
{
    public class CreateWeatherForecastCommand : IRequest<WeatherForecast>
    {
        public WeatherForecast WeatherForecast { get; set; }
    }
}