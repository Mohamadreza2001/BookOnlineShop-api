using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Query.SiteEntites.Banners.GetList
{
    internal class GetListBannerQueryHandler : IQueryHandler<GetListBannerQuery, List<BannerDto>>
    {
        private readonly ShopContext _context;

        public GetListBannerQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<BannerDto>> Handle(GetListBannerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Banners.OrderByDescending(i => i.Id).Select(i => new BannerDto()
            {
                Id = i.Id,
                CreationDate = i.CreationDate,
                ImageName = i.ImageName,
                Link = i.Link,
                Position = i.Position,
            }).ToListAsync(cancellationToken);
        }
    }
}
