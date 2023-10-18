using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById
{
    internal class GetByIdSellerQueryHandler : IQueryHandler<GetByIdSellerQuery, SellerDto?>
    {
        private readonly ShopContext _context;

        public GetByIdSellerQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerDto?> Handle(GetByIdSellerQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(i => i.Id == request.SellerId);
            if (seller == null)
                return null;
            return seller.Map();
        }
    }
}
