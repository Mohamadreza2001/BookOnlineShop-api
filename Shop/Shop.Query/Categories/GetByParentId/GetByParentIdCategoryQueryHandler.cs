using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId
{
    internal class GetByParentIdCategoryQueryHandler : IQueryHandler<GetByParentIdCategoryQuery, List<ChildCategoryDto>>
    {
        private readonly ShopContext _context;

        public GetByParentIdCategoryQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<ChildCategoryDto>> Handle(GetByParentIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories
                .Include(i => i.Childs)
                .Where(i => i.ParentId == request.ParentId)
                .ToListAsync(cancellationToken);
            return result.MapChildren();
        }
    }
}
