using Common.Query;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Query.SiteEntites.Banners.GetList
{
    public record GetListBannerQuery : IQuery<List<BannerDto>>;
}
