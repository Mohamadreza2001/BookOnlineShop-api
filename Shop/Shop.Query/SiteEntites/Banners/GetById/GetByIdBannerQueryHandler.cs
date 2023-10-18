using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Query.SiteEntites.Banners.GetById
{
    internal class GetByIdBannerQueryHandler : IQueryHandler<GetByIdBannerQuery, BannerDto?>
    {
        private readonly ShopContext _context;

        public GetByIdBannerQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<BannerDto?> Handle(GetByIdBannerQuery request, CancellationToken cancellationToken)
        {
            var banner = await _context.Banners.FirstOrDefaultAsync(i => i.Id == request.BannerId, cancellationToken);
            if (banner == null)
                return null;
            return new BannerDto()
            {
                Id = banner.Id,
                CreationDate = banner.CreationDate,
                ImageName = banner.ImageName,
                Link = banner.Link,
                Position = banner.Position,
            };
        }
    }
}
