using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetBySlug
{
    internal class GetBySlugProductQueryHandler : IQueryHandler<GetBySlugProductQuery, ProductDto?>
    {
        private readonly ShopContext _context;

        public GetBySlugProductQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(GetBySlugProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(i => i.Slug == request.ProductSlug, cancellationToken);
            var model = product.Map();
            if (model == null)
                return null;
            await model.SetCategories(_context);
            return model;
        }
    }
}
