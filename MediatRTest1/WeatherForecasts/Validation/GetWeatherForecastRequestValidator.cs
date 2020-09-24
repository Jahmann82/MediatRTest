using FluentValidation;
using MediatRTest1.WeatherForecasts.RequestModels.QueryRequestModels;

namespace MediatRTest1.WeatherForecasts.Validation
{
    public class GetWeatherForecastRequestValidator : AbstractValidator<GetWeatherForecastQuery>
    {
        public GetWeatherForecastRequestValidator()
        {
            RuleFor(c => c.ForecastDays).GreaterThan(0).WithMessage(c => $"Minimum forecast is one day and not {c.ForecastDays}");
            RuleFor(c => c.ForecastDays).LessThan(15).WithMessage(c => $"Maximum forecast is 14 days and not {c.ForecastDays}");
        }
    }
}