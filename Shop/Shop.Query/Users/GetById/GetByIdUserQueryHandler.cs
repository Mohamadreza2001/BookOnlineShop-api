using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetById
{
    internal class GetByIdUserQueryHandler : IQueryHandler<GetByIdUserQuery, UserDto?>
    {
        private readonly ShopContext _context;

        public GetByIdUserQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == request.UserId, cancellationToken);
            if (user == null)
                return null;
            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}
