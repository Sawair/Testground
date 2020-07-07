using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatRDemo.Api.Infrastructure;
using MediatRDemo.Api.Models;
using Microsoft.Extensions.Logging;

namespace MediatRDemo.Api.DTO.Queries
{
    public class GetAllWeatherForecastsQuery : BaseRequest, IQuery<IEnumerable<WeatherForecast>>
    {
    }

    public class GetAllWeatherForecastsQueryHandler : IQueryHandler<GetAllWeatherForecastsQuery, IEnumerable<WeatherForecast>>
    {
        private readonly FakeDbContext _dbContext;
        private readonly ILogger<GetAllWeatherForecastsQueryHandler> _logger;

        public GetAllWeatherForecastsQueryHandler(FakeDbContext dbContext, ILogger<GetAllWeatherForecastsQueryHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<Response<IEnumerable<WeatherForecast>>> Handle(GetAllWeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            var result = _dbContext.WeatherForecasts;
            _logger.LogInformation("Found {numberOfResults} results.", result.Count);
            return Task.FromResult(ResponseFactory.Ok(result.AsEnumerable()));
        }
    }
}
