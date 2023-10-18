using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetByFilter
{
    public class GetByFilterProductQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
    {
        public GetByFilterProductQuery(ProductFilterParams filterParam) : base(filterParam)
        {
        }
    }
}
