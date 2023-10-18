using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByPhoneNumber
{
    internal class GetByPhoneNumberUserQueryHandler : IQueryHandler<GetByPhoneNumberUserQuery, UserDto?>
    {
        private readonly ShopContext _context;

        public GetByPhoneNumberUserQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(GetByPhoneNumberUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.PhoneNumber == request.PhoneNumber, cancellationToken);
            if (user == null)
                return null;
            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}
