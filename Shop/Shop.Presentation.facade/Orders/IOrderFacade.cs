using Common.Application;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.CheckOut;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;

namespace Shop.Presentation.facade.Orders
{
    public interface IOrderFacade
    {
        Task<OperationResult> AddItem(AddItemOrderCommand command);
        Task<OperationResult> CheckOut(CheckOutOrderCommand command);
        Task<OperationResult> DecreaseItemCount(DecreaseItemCountOrderCommand command);
        Task<OperationResult> IncreaseItemCount(IncreaseItemCountCommand command);
        Task<OperationResult> RemoveItem(RemoveItemOrderCommand command);

        Task<OrderDto?> GetById(long id);
        Task<OrderFilterResult> GetByFilter(OrderFilterParams filterParams);
    }
}
