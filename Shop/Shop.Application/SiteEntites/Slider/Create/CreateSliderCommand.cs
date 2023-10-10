using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntites.Slider.Create
{
    public record CreateSliderCommand(string Title, IFormFile ImageFile, string Link) : IBaseCommand;
}
