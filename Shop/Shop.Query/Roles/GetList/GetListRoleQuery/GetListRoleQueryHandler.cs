using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetList.GetListRoleQuery
{
    internal class GetListRoleQueryHandler : IQueryHandler<GetListRoleQuery, List<RoleDto>>
    {
        private readonly ShopContext _context;

        public GetListRoleQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<RoleDto>> Handle(GetListRoleQuery request, CancellationToken cancellationToken)
        {
            return await _context.Roles.Select(i => new RoleDto()
            {
                Id = i.Id,
                CreationDate = i.CreationDate,
                Title = i.Title,
                Permissions = i.Permissions.Select(i => i.Permission).ToList(),
            }).ToListAsync(cancellationToken);
        }
    }
}
