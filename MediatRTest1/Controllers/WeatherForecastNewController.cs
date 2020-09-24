using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatRTest1.Contracts;
using MediatRTest1.WeatherForecasts.RequestModels.CommandRequestModels;
using MediatRTest1.WeatherForecasts.RequestModels.QueryRequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MediatRTest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastNewController : ControllerBase
    {
        private readonly IMediator mediator;

        public WeatherForecastNewController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{forecastDays}")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get(int forecastDays)
        {
            var forecast = await mediator.Send(new GetWeatherForecastQuery(forecastDays));

            if (!forecast.Any())
            {
                return NotFound();
            }

            return Ok(forecast);
        }

        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> Create([FromBody] CreateWeatherForecastCommand command)
        {
            var forecast = await mediator.Send(command);

            if (forecast == null)
            {
                return BadRequest();
            }

            return Ok(forecast);
        }
    }
}