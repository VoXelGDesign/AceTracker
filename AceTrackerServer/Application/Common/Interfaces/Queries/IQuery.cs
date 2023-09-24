using MediatR;

namespace Application.Common.Interfaces.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
