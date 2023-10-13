using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById
{
    public record GetByIdCategoryQuery(long CategoryId) : IQuery<CategoryDto>;
}
