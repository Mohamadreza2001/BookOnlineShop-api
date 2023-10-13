using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId
{
    public record GetByParentIdCategoryQuery(long ParentId) : IQuery<List<ChildCategoryDto>>;
}
