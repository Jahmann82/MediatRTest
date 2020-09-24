using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRTest1.Contracts;
using MediatRTest1.WeatherForecasts.RequestModels.CommandRequestModels;

namespace MediatRTest1.WeatherForecasts.Handlers.CommandHandlers
{
    public class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, WeatherForecast>
    {
        public Task<WeatherForecast> Handle(CreateWeatherForecastCommand command, CancellationToken cancellationToken)
        {
            var weatherForecast = command.WeatherForecast;
            // save to universe

            return Task.FromResult(weatherForecast);
        }
    }
}