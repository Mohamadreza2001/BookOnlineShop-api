using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByFilter
{
    internal class GetByFilterUserQueryHandler : IQueryHandler<GetByFilterUserQuery, UserFilterResult>
    {
        private readonly ShopContext _context;

        public GetByFilterUserQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserFilterResult> Handle(GetByFilterUserQuery request, CancellationToken cancellationToken)
        {
            var param = request.FilterParams;
            var result = _context.Users.OrderByDescending(i => i.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.Email))
                result = result.Where(i => i.Email.Contains(param.Email));

            if (!string.IsNullOrWhiteSpace(param.PhoneNumber))
                result = result.Where(i => i.PhoneNumber.Contains(param.PhoneNumber));

            if (param.UserId != null)
                result = result.Where(i => i.Id == param.UserId);

            var skip = (param.PageId - 1) * param.Take;
            var model = new UserFilterResult()
            {
                Data = await result.Skip(skip).Take(param.Take).Select(i => i.MapFilterData()).ToListAsync(cancellationToken),
                FilterParams = param,
            };
            model.GeneratePaging(result, param.Take, param.PageId);
            return model;
        }
    }
}
