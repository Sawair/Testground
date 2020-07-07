using MediatR;

namespace MediatRDemo.Api.DTO
{
    public interface ICommand : IRequest<Response> { }

    public interface ICommandHandler<T> : IRequestHandler<T, Response> where T : ICommand { }
}