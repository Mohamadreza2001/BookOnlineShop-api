using Common.Query;
using Shop.Domain.SiteEntites.Enums;

namespace Shop.Query.SiteEntites.DTOs
{
    public class BannerDto : BaseDto
    {
        public string Link { get; set; }
        public string ImageName { get; set; }
        public BannerPosition Position { get; set; }
    }
}
