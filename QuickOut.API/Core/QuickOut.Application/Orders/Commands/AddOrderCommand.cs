
using QuickOut.Application.Common;
using QuickOut.Domain.Orders;
using QuickOut.Library;
using System.Windows.Input;

namespace QuickOut.Application.Orders.Commands
{
    public class AddOrderCommand : ICommand<Guid>
    {
        public Guid UserId { get; set; }
        public Guid EstabilishmentId { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }

        public AddOrderCommand(Guid userId, Guid estabilishmentId, DateTime date, double totalValue)
        {
            UserId = userId;
            EstabilishmentId = estabilishmentId;
            Date = date;
            TotalValue = totalValue;
        }
    }

    public class AddOrderCommandHandler : ICommandHandler<AddOrderCommand, Guid>
    {
        private readonly IOrderRepository repository;
        private readonly IDomainEventManager domainEvent;

        public AddOrderCommandHandler(IOrderRepository repository, IDomainEventManager domainEvent)
        {
            this.repository = repository;
            this.domainEvent = domainEvent;
        }

        public Task<Result<Guid>> Handle(AddOrderCommand parameters)
        {
            Result<Order> createResult = Order.New(parameters.UserId, parameters.EstabilishmentId);

            if(!createResult.Succeeded)
            {
                return Result<Guid>.Fail(createResult.Messages).AsTask();
            }

            repository.Add(createResult.Data);

            return Result<Guid>.Success(createResult.Data.Id).AsTask();
        }
    }
}