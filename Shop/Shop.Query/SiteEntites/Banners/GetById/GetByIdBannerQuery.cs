using Common.Query;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Query.SiteEntites.Banners.GetById
{
    public record GetByIdBannerQuery(long BannerId) : IQuery<BannerDto?>;
}
