using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter
{
    internal class GetByFilterOrderQueryHandler : IQueryHandler<GetByFilterOrderQuery, OrderFilterResult>
    {
        private readonly ShopContext _context;

        public GetByFilterOrderQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<OrderFilterResult> Handle(GetByFilterOrderQuery request, CancellationToken cancellationToken)
        {
            var param = request.FilterParams;

            var result = _context.Orders.OrderByDescending(i => i.Id).AsQueryable();

            if (param.Status != null)
                result = result.Where(i => i.Status == param.Status);

            if (param.UserId != null)
                result = result.Where(i => i.UserId == param.UserId);

            if (param.StartDate != null)
                result = result.Where(i => i.CreationDate.Date >= param.StartDate.Value.Date);

            if (param.EndDate != null)
                result = result.Where(i => i.CreationDate.Date <= param.EndDate.Value.Date);

            var skip = (param.PageId - 1) * param.Take;

            var model = new OrderFilterResult()
            {
                Data = await result.Skip(skip).Take(param.Take)
                .Select(order => order.MapFilterData(_context))
                .ToListAsync(cancellationToken),
                FilterParams = param,
            };

            model.GeneratePaging(result, param.Take, param.PageId);
            
            return model;
        }
    }
}
