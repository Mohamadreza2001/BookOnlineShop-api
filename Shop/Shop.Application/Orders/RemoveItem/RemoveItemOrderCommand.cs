using Common.Application;

namespace Shop.Application.Orders.RemoveItem
{
    public record RemoveItemOrderCommand(long UserId, long ItemId) : IBaseCommand;
}
