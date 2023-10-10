using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntites.Enums;

namespace Shop.Application.SiteEntites.Banner.Create
{
    public record CreateBannerCommand(string Link, IFormFile ImageFile, BannerPosition Position) : IBaseCommand;
}
