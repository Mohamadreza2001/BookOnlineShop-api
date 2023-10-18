using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetByFilter
{
    public class GetByFilterProductQueryHandler : IQueryHandler<GetByFilterProductQuery, ProductFilterResult>
    {
        private readonly ShopContext _context;

        public GetByFilterProductQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<ProductFilterResult> Handle(GetByFilterProductQuery request, CancellationToken cancellationToken)
        {
            var param = request.FilterParams;
            var result = _context.Products.OrderByDescending(i => i.Id).AsQueryable();

            if (param.ProductId != null)
                result = result.Where(i => i.Id == param.ProductId);

            if (!string.IsNullOrWhiteSpace(param.Slug))
                result = result.Where(i => i.Slug == param.Slug);

            if (!string.IsNullOrWhiteSpace(param.Title))
                result = result.Where(i => i.Title.Contains(param.Title));

            var skip = (param.PageId - 1) * param.Take;
            var model = new ProductFilterResult()
            {
                Data = await result.Skip(skip).Take(param.Take).Select(i => i.MapListData()).ToListAsync(),
                FilterParams = param,
            };
            model.GeneratePaging(result, param.Take, param.PageId);
            return model;
        }
    }
}
