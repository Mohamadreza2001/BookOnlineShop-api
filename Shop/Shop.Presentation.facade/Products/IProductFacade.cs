using Common.Application;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.DTOs.ProductShop;

namespace Shop.Presentation.facade.Products
{
    public interface IProductFacade
    {
        Task<OperationResult> AddImage(AddImageProductCommand command);
        Task<OperationResult> Create(CreateProductCommand command);
        Task<OperationResult> Edit(EditProductCommand command);
        Task<OperationResult> RemoveImage(RemoveImageProductCommand command);

        Task<ProductFilterResult> GetByFilter(ProductFilterParams filterParams);
        Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams);
        Task<ProductDto?> GetById(long id);
        Task<ProductDto?> GetBySlug(string productSlug);
    }
}
