using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntites.Repositories
{
    internal class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
    {
        public ShippingMethodRepository(ShopContext context) : base(context)
        {
        }

        public void Delete(ShippingMethod slider)
        {
            _context.ShippingMethods.Remove(slider);
        }
    }
}
