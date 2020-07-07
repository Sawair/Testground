using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Api.Infrastructure;
using MediatRDemo.Api.Models;
using Microsoft.Extensions.Logging;

namespace MediatRDemo.Api.DTO.Commands
{
    public class CreateWeatherForecastCommand : BaseRequest, ICommand
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }

    public class CreateWeatherForecastCommandHandler : ICommandHandler<CreateWeatherForecastCommand>
    {
        private readonly ILogger<CreateWeatherForecastCommandHandler> _logger;
        private readonly FakeDbContext _context;

        public CreateWeatherForecastCommandHandler(ILogger<CreateWeatherForecastCommandHandler> logger, FakeDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public Task<Response> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var errorList = new List<string>();
            if (request.Date < DateTime.Today)
            {
                errorList.Add("To late");
            }

            if (request.TemperatureC > 40)
            {
                errorList.Add("It's to hot");
            }

            if (errorList.Any())
            {
                return Task.FromResult(ResponseFactory.Fail(errorList.ToArray()));
            }

            var weatherForecast = new WeatherForecast()
            {
                Date = request.Date,
                TemperatureC = request.TemperatureC,
                Summary = request.Summary
            };

            _context.WeatherForecasts.Add(weatherForecast);
            _logger.LogInformation("Created new weather forecast {@weatherForecast}", weatherForecast);
            
            return Task.FromResult(ResponseFactory.Ok());
        }
    }
}
