using Common.Application;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Query.Categories.DTOs;

namespace Shop.Presentation.facade.Categories
{
    public interface ICategoryFacade
    {
        Task<OperationResult> AddChild(AddChildCategoryCommand command);
        Task<OperationResult> Create(CreateCategoryCommand command);
        Task<OperationResult> Edit(EditCategoryCommand command);

        Task<CategoryDto> GetCategoryById(long id);
        Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId);
        Task<List<CategoryDto>> GetCategories();
    }
}
