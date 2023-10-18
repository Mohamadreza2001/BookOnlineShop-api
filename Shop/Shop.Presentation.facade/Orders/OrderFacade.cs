using Common.Application;
using MediatR;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.CheckOut;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.GetByFilter;
using Shop.Query.Orders.GetById;

namespace Shop.Presentation.facade.Orders
{
    internal class OrderFacade : IOrderFacade
    {
        private readonly IMediator _mediator;

        public OrderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddItem(AddItemOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> CheckOut(CheckOutOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DecreaseItemCount(DecreaseItemCountOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OrderFilterResult> GetByFilter(OrderFilterParams filterParams)
        {
            return await _mediator.Send(new GetByFilterOrderQuery(filterParams));
        }

        public async Task<OrderDto?> GetById(long id)
        {
            return await _mediator.Send(new GetByIdOrderQuery(id));
        }

        public async Task<OperationResult> IncreaseItemCount(IncreaseItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RemoveItem(RemoveItemOrderCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
