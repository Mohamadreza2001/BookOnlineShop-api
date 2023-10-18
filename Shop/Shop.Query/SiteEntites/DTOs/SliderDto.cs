﻿using Common.Query;

namespace Shop.Query.SiteEntites.DTOs
{
    public class SliderDto : BaseDto
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string ImageName { get; set; }
    }
}
