using Common.Application;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.Remove;
using Shop.Query.Categories.DTOs;

namespace Shop.Presentation.facade.Categories
{
    public interface ICategoryFacade
    {
        Task<OperationResult<long>> AddChild(AddChildCategoryCommand command);
        Task<OperationResult<long>> Create(CreateCategoryCommand command);
        Task<OperationResult> Edit(EditCategoryCommand command);
        Task<OperationResult> RemoveCategory(long categoryId);

        Task<CategoryDto> GetCategoryById(long id);
        Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId);
        Task<List<CategoryDto>> GetCategories();
    }
}
