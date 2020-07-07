using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Api.DTO.Commands;
using MediatRDemo.Api.DTO.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatRDemo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllWeatherForecastsQuery());
            return response.Error ? (IActionResult) BadRequest(response) : Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWeatherForecastCommand command)
        {
            var response = await _mediator.Send(command);
            return response.Error ? (IActionResult) BadRequest(response) : Accepted(response);
        }
    }
}
