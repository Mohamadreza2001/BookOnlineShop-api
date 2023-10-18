using Common.Application;
using MediatR;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetByFilter;
using Shop.Query.Products.GetById;
using Shop.Query.Products.GetBySlug;

namespace Shop.Presentation.facade.Products
{
    internal class ProductFacade : IProductFacade
    {
        private readonly IMediator _mediator;

        public ProductFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddImage(AddImageProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ProductFilterResult> GetByFilter(ProductFilterParams filterParams)
        {
            return await _mediator.Send(new GetByFilterProductQuery(filterParams));
        }

        public async Task<ProductDto?> GetById(long id)
        {
            return await _mediator.Send(new GetByIdProductQuery(id));
        }

        public async Task<ProductDto?> GetBySlug(string productSlug)
        {
            return await _mediator.Send(new GetBySlugProductQuery(productSlug));
        }

        public async Task<OperationResult> RemoveImage(RemoveImageProductCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
