using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntites.Enums;

namespace Shop.Application.SiteEntites.Banner.Edit
{
    public record EditBannerCommand(long BannerId, string Link, IFormFile? ImageFile, BannerPosition Position) : IBaseCommand;
}
