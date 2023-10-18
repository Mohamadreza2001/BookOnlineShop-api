using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByFilter
{
    public class GetByFilterSellerQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
    {
        public GetByFilterSellerQuery(SellerFilterParams filterParam) : base(filterParam)
        {
        }
    }
}
