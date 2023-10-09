using Common.Application;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long SellerId, string NationalCode, string ShopName) : IBaseCommand;
}
