using Common.Application;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public record IncreaseItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}
