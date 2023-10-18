using Common.Query;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetList.GetListRoleQuery
{
    public record GetListRoleQuery : IQuery<List<RoleDto>>;
}
