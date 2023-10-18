using Common.Query;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Query.SiteEntites.Sliders.GetList
{
    public record GetListSliderQuery : IQuery<List<SliderDto>>;
}
