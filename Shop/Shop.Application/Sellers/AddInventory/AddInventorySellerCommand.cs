using Common.Application;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddInventorySellerCommand : IBaseCommand
    {
        public AddInventorySellerCommand(long productId, long sellerId, int count, int price, int? percentageDiscount)
        {
            ProductId = productId;
            SellerId = sellerId;
            Count = count;
            Price = price;
            PercentageDiscount = percentageDiscount;
        }

        public long ProductId { get; private set; }
        public long SellerId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? PercentageDiscount { get; private set; }
    }
}
