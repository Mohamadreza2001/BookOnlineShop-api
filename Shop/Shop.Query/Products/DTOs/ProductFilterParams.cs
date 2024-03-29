﻿using Common.Query.Filter;

namespace Shop.Query.Products.DTOs
{
    public class ProductFilterParams : BaseFilterParam
    {
        public string? Title { get; set; }
        public long? ProductId { get; set; }
        public string? Slug { get; set; }
    }
}
