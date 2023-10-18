using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetById
{
    public record GetByIdProductQuery(long ProductId) : IQuery<ProductDto?>;
}
