using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetById
{
    internal class GetByIdRoleQueryHandler : IQueryHandler<GetByIdRoleQuery, RoleDto?>
    {
        private readonly ShopContext _context;

        public GetByIdRoleQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<RoleDto?> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(i => i.Id == request.RoleId, cancellationToken);
            if (role == null)
                return null;
            return new RoleDto()
            {
                Id = role.Id,
                CreationDate = role.CreationDate,
                Title = role.Title,
                Permissions = role.Permissions.Select(i => i.Permission).ToList(),
            };
        }
    }
}
