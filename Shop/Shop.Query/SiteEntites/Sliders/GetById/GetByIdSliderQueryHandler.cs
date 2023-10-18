using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Query.SiteEntites.Sliders.GetById
{
    internal class GetByIdSliderQueryHandler : IQueryHandler<GetByIdSliderQuery, SliderDto?>
    {
        private readonly ShopContext _context;

        public GetByIdSliderQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SliderDto?> Handle(GetByIdSliderQuery request, CancellationToken cancellationToken)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(i => i.Id == request.SliderId, cancellationToken);
            if (slider == null)
                return null;
            return new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                Title = slider.Title,
                Link = slider.Link,
                ImageName = slider.ImageName,
            };
        }
    }
}
