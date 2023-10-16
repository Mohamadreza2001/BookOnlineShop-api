using Common.Query.Filter;
using Shop.Domain.OrderAgg.Enums;

namespace Shop.Query.Orders.DTOs
{
    public class OrderFilterParams : BaseFilterParam
    {
        public long? UserId { set; get; }
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        public OrderStatus? Status { get; set; }
    }
}
