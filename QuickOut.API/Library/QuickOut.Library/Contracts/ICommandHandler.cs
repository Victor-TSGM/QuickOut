using QuickOut.Library;

namespace QuickOut.Application.Common
{
    public interface ICommandHandler<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
        Task<Result<TResponse>> Handle(TRequest parameters);
    }

    public interface IQueryHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest parameters);
    }

    public interface ITransactionalDomainEventHandler<TEvent> where TEvent : IDomainEvent
    {
        Task<Result> Handle(TEvent parameters);
    }
}
