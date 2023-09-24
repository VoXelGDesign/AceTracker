using MediatR;

namespace Infrastructure.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
