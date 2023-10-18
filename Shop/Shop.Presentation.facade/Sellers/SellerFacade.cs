using Common.Application;
using MediatR;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.GetByFilter;
using Shop.Query.Sellers.GetById;

namespace Shop.Presentation.facade.Sellers
{
    internal class SellerFacade : ISellerFacade
    {
        private readonly IMediator _mediator;

        public SellerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> Create(CreateSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<SellerFilterResult> GetByFilter(SellerFilterParams filterParams)
        {
            return await _mediator.Send(new GetByFilterSellerQuery(filterParams));
        }

        public async Task<SellerDto?> GetById(long id)
        {
            return await _mediator.Send(new GetByIdSellerQuery(id));
        }
    }
}
