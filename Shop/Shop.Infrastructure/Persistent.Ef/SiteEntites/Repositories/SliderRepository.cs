using Shop.Domain.SiteEntites.Repositories;
using Shop.Domain.SiteEntites;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntites.Repositories
{
    internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        public SliderRepository(ShopContext context) : base(context)
        {
        }

        public void Delete(Slider slider)
        {
            _context.Sliders.Remove(slider);
        }
    }
}
