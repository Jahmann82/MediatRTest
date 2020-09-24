using Galaxus.Functional;
using MediatRTest1.Contracts;

namespace MediatRTest1.WeatherForecasts.Validation
{
    public class WeatherForecastValidatorService : IWeatherForecastValidatorService
    {
        public Result<Unit, string> Validate(int forecastDays)
        {
            if (forecastDays <= 0)
            {
                return $"Minimum forecast is one day and not {forecastDays}";
            }

            if (forecastDays > 14)
            {
                return $"Maximum forecast is 14 days and not {forecastDays}";
            }

            return new Unit();
        }
    }
}