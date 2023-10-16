﻿using Common.Query;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Query.Orders.DTOs
{
    public class OrderDto : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderDiscount? OrderDiscount { get; set; }
        public OrderAddress? OrderAddress { get; set; }
        public ShippingMethod? ShippingMethod { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
