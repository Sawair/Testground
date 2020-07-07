using MediatR;

namespace MediatRDemo.Api.DTO
{
    public interface IQuery<T> : IRequest<Response<T>> { }
    public interface IQueryHandler<TIn, TOut> : IRequestHandler<TIn, Response<TOut>> where TIn : IQuery<TOut> { }
}