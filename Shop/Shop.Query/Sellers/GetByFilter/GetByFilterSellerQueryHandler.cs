using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByFilter
{
    internal class GetByFilterSellerQueryHandler : IQueryHandler<GetByFilterSellerQuery, SellerFilterResult>
    {
        private readonly ShopContext _context;

        public GetByFilterSellerQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerFilterResult> Handle(GetByFilterSellerQuery request, CancellationToken cancellationToken)
        {
            var param = request.FilterParams;
            var result = _context.Sellers.OrderByDescending(i => i.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.NationalCode))
                result = result.Where(i => i.NationalCode.Contains(param.NationalCode));

            if (!string.IsNullOrWhiteSpace(param.ShopName))
                result = result.Where(i => i.NationalCode.Contains(param.ShopName));
            var skip = (param.PageId - 1) * param.Take;
            var sellerResult = new SellerFilterResult()
            {
                FilterParams = param,
                Data = await result.Skip(skip).Take(param.Take).Select(i => i.Map()).ToListAsync(cancellationToken),
            };
            sellerResult.GeneratePaging(result, param.Take, param.PageId);
            return sellerResult;
        }
    }
}
