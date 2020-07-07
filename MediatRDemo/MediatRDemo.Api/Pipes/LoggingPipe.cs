using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MediatRDemo.Api.Pipes
{
    public class LoggingPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private readonly ILogger<LoggingPipe<TIn, TOut>> _logger;

        public LoggingPipe(ILogger<LoggingPipe<TIn, TOut>> logger)
        {
            _logger = logger;
        }

        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            _logger.LogInformation("Get request {@request}", request);

            var response = await next();

            _logger.LogInformation("Returned {@response}", response);

            return response;
        }
    }
}