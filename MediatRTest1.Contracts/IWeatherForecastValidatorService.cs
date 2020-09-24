using Galaxus.Functional;

namespace MediatRTest1.Contracts
{
    public interface IWeatherForecastValidatorService
    {
        Result<Unit, string> Validate(int forecastDays);
    }
}