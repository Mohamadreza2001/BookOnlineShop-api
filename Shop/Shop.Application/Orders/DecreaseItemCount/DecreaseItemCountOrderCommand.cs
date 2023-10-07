using Common.Application;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public record DecreaseItemCountOrderCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}
