using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Api.DTO;
using MediatRDemo.Api.Infrastructure;

namespace MediatRDemo.Api.Pipes
{
    public class RequestMetadataFillPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        public Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            if (request is BaseRequest br)
            {
                br.RequestTime = DateTime.Now;
            }

            return next();
        }
    }
}