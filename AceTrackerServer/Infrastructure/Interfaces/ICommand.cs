using MediatR;

namespace Infrastructure.Interfaces
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
