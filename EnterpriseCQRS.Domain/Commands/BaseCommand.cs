using MediatR;

namespace EnterpriseCQRS.Domain.Commands
{
    public abstract class BaseCommand<T> : IRequest<T>
    {
    }
}
