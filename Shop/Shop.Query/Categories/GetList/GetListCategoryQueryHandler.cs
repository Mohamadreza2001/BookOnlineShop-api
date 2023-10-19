using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList
{
    internal class GetListCategoryQueryHandler : IQueryHandler<GetListCategoryQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetListCategoryQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories
                .Where(i => i.ParentId == null)
                .Include(i => i.Childs)
                .ThenInclude(i => i.Childs)
                .OrderByDescending(i => i.Id).ToListAsync(cancellationToken);
            return result.Map();
        }
    }
}
