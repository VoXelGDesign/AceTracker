using MediatR;

namespace Application.Common.Interfaces.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
