using Common.Query;
using Shop.Domain.OrderAgg.Enums;

namespace Shop.Query.Orders.DTOs
{
    public class OrderFilterData : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public int TotalPrice { set; get; }
        public int TotalItemCount { set; get; }
        public string? ShippingType { get; set; }
    }
}
