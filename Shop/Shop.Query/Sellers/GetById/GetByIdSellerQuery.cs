using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById
{
    public record GetByIdSellerQuery(long SellerId) : IQuery<SellerDto?>;
}
