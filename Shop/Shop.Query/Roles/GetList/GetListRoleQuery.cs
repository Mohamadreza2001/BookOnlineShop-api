using Common.Query;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetList
{
    public record GetListRoleQuery : IQuery<List<RoleDto>>;
}
