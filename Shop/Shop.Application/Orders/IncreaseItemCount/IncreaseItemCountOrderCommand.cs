using Common.Application;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public record IncreaseItemCountOrderCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}
