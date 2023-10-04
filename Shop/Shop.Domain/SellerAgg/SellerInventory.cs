using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        public SellerInventory(long productId, int count, int price, long sellerId)
        {
            if (price < 1 || count < 0)
                throw new InvalidDomainDataException();
            ProductId = productId;
            Count = count;
            Price = price;
            SellerId = sellerId;
        }

        public long ProductId { get; private set; }
        public long SellerId { get; internal set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
    }
}
