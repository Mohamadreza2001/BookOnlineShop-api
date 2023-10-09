using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory
{
    internal class AddInventorySellerCommandHandler : IBaseCommandHandler<AddInventorySellerCommand>
    {
        private readonly ISellerRepository _repository;

        public AddInventorySellerCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddInventorySellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();
            seller.AddInventory(new SellerInventory(request.ProductId, request.Count, request.Price, request.SellerId,
                request.PercentageDiscount));
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
