using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetBySlug
{
    public record GetBySlugProductQuery(string ProductSlug) : IQuery<ProductDto?>;
}
