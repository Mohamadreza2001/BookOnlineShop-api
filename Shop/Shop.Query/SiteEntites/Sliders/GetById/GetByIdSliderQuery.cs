using Common.Query;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Query.SiteEntites.Sliders.GetById
{
    public record GetByIdSliderQuery(long SliderId) : IQuery<SliderDto?>;
}
