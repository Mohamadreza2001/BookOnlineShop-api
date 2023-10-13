using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList
{
    public record GetListCategoryQuery : IQuery<List<CategoryDto>>;
}
