using Common.Query;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter
{
    public class GetByFilterOrderQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
    {
        public GetByFilterOrderQuery(OrderFilterParams filterParam) : base(filterParam)
        {
        }
    }
}
