using Common.Application;
using Common.Application.Validation;

namespace Shop.Application.Orders.AddItem
{
    public record AddItemOrderCommand(long InventoryId, int Count, long UserId) : IBaseCommand;
}
