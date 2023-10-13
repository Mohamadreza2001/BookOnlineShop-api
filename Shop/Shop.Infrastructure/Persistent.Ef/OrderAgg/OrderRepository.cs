using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg.Enums;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(ShopContext context) : base(context)
        {
        }
        public async Task<Order?> GetCurrentUserOrder(long userId)
        {
            return await _context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId
            && f.Status == OrderStatus.Pending);
        }
    }
}
