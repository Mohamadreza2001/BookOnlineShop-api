using Common.Application;
using Shop.Domain.SellerAgg.Enums;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long SellerId, string NationalCode, string ShopName, SellerStatus Status) : IBaseCommand;
}
