using Common.Query;
using Shop.Query.Products.DTOs.ProductShop;

namespace Shop.Query.Products.GetForShop
{
    public class GetProductsForShopQuery : QueryFilter<ProductShopResult, ProductShopFilterParam>
    {
        public GetProductsForShopQuery(ProductShopFilterParam filterParam) : base(filterParam)
        {
        }
    }
}
