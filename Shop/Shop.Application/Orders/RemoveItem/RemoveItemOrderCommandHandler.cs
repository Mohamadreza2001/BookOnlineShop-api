using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.RemoveItem
{
    public class RemoveItemOrderCommandHandler : IBaseCommandHandler<RemoveItemOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public RemoveItemOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveItemOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();
            currentOrder.RemoveItem(request.ItemId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
