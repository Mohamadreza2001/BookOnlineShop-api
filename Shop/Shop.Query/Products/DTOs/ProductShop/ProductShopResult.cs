using Common.Query.Filter;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Products.DTOs.ProductShop
{
    public class ProductShopResult : BaseFilter<ProductShopDto, ProductShopFilterParam>
    {
        public CategoryDto? CategoryDto { get; set; }
    }
}
