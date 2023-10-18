using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByFilter
{
    public class GetByFilterUserQuery : QueryFilter<UserFilterResult, UserFilterParams>
    {
        public GetByFilterUserQuery(UserFilterParams filterParam) : base(filterParam)
        {
        }
    }
}
