using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Query.SiteEntites.Sliders.GetList
{
    internal class GetListSliderQueryHandler : IQueryHandler<GetListSliderQuery, List<SliderDto>>
    {
        private readonly ShopContext _context;

        public GetListSliderQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<SliderDto>> Handle(GetListSliderQuery request, CancellationToken cancellationToken)
        {
            return await _context.Sliders.OrderByDescending(i => i.Id).Select(i => new SliderDto()
            {
                Id = i.Id,
                CreationDate = i.CreationDate,
                Title = i.Title,
                Link = i.Link,
                ImageName = i.ImageName,
            }).ToListAsync(cancellationToken);
        }
    }
}
