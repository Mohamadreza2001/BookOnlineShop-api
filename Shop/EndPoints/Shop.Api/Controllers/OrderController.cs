using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.CheckOut;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Presentation.facade.Orders;
using Shop.Query.Orders.DTOs;

namespace Shop.Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderFacade _orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        [HttpGet("{orderId}")]
        public async Task<ApiResult<OrderDto?>> GetOrderById(long orderId)
        {
            return QueryResult(await _orderFacade.GetById(orderId));
        }

        [HttpGet]
        public async Task<ApiResult<OrderFilterResult>> GetOrderByFilter([FromQuery] OrderFilterParams filterParams)
        {
            return QueryResult(await _orderFacade.GetByFilter(filterParams));
        }

        [HttpPost]
        public async Task<ApiResult> AddOrderItem(AddItemOrderCommand command)
        {
            return CommandResult(await _orderFacade.AddItem(command));
        }

        [HttpPost("checkOut")]
        public async Task<ApiResult> CheckOutOrder(CheckOutOrderCommand command)
        {
            return CommandResult(await _orderFacade.CheckOut(command));
        }

        [HttpPut("orderItem/increaseCount")]
        public async Task<ApiResult> IncreaseItemCountOrder(IncreaseItemCountOrderCommand command)
        {
            return CommandResult(await _orderFacade.IncreaseItemCount(command));
        }

        [HttpPut("orderItem/decreaseCount")]
        public async Task<ApiResult> DecreaseItemCountOrder(DecreaseItemCountOrderCommand command)
        {
            return CommandResult(await _orderFacade.DecreaseItemCount(command));
        }

        [HttpDelete("orderItem")]
        public async Task<ApiResult> RemoveOrderItem(RemoveItemOrderCommand command)
        {
            return CommandResult(await _orderFacade.RemoveItem(command));
        }
    }
}
