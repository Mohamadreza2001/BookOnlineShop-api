using Shop.Domain.SellerAgg;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers
{
    public static class SllerMapper
    {
        public static SellerDto Map(this Seller seller)
        {
            if (seller == null)
                return null;
            return new SellerDto()
            {
                Id = seller.Id,
                CreationDate = seller.CreationDate,
                ShopName = seller.ShopName,
                NationalCode = seller.NationalCode,
                Status = seller.Status,
                UserId = seller.UserId,
            };
        }
    }
}
