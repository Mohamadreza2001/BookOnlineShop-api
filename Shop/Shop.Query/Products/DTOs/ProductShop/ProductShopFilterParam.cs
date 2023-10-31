using Common.Query.Filter;
using Shop.Query.Products.DTOs.ProductShop.Enum;

namespace Shop.Query.Products.DTOs.ProductShop
{
    public class ProductShopFilterParam : BaseFilterParam
    {
        public string? CategorySlug { get; set; } = string.Empty;
        public string? Search { get; set; } = string.Empty;
        public bool OnlyAvailableProducts { get; set; } = false;
        public bool JustHasDiscount { get; set; } = false;
        public ProductSearchOrderBy SearchOrderBy { get; set; } = ProductSearchOrderBy.Cheapest;
    }
}
