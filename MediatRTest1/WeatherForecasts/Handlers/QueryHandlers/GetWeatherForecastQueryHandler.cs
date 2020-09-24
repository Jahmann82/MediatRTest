using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRTest1.Contracts;
using MediatRTest1.WeatherForecasts.RequestModels.QueryRequestModels;

namespace MediatRTest1.WeatherForecasts.Handlers.QueryHandlers
{
    public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IImmutableList<WeatherForecast>>
    {
        private readonly IWeatherForecastService weatherForecastService;

        public GetWeatherForecastQueryHandler(IWeatherForecastService weatherForecastService)
        {
            this.weatherForecastService = weatherForecastService;
        }

        public Task<IImmutableList<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var weatherForecasts = weatherForecastService.GetWeatherForecasts(request.ForecastDays);

            return Task.FromResult(weatherForecasts);
        }
    }
}