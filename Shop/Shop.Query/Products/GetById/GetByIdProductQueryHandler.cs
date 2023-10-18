using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetById
{
    internal class GetByIdProductQueryHandler : IQueryHandler<GetByIdProductQuery, ProductDto?>
    {
        private readonly ShopContext _context;

        public GetByIdProductQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(i => i.Id == request.ProductId, cancellationToken);
            var model = product.Map();
            if (model == null)
                return null;
            await model.SetCategories(_context);
            return model;
        }
    }
}
