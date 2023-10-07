using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseItemCountCommandHandler : IBaseCommandHandler<IncreaseItemCountCommand>
    {
        private readonly IOrderRepository _repository;

        public IncreaseItemCountCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(IncreaseItemCountCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();
            currentOrder.IncreaseItemCount(request.ItemId, request.Count);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
