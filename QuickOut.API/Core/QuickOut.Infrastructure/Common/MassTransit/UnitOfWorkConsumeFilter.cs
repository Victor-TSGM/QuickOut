using QuickOut.Library;
using MassTransit;
using QuickOut.Infrastructure;

namespace Fazsoft.Infrastructure;

public class UnitOfWorkConsumeFilter<T> : IFilter<ConsumeContext<T>> where T : class
{
    private readonly UnitOfWork _unitOfWork;

    public UnitOfWorkConsumeFilter(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
    {
        await next.Send(context);

        Result? result = _unitOfWork.Commit();

        if (!result.Succeeded)
        {
            await context.RespondAsync(result.Messages);
        }
    }

    public void Probe(ProbeContext context) { }
}