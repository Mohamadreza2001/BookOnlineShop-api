using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter
{
    internal class GetByFilterCommentQueryHandler : IQueryHandler<GetByFilterCommentQuery, CommentFilterResult>
    {
        private readonly ShopContext _context;

        public GetByFilterCommentQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CommentFilterResult> Handle(GetByFilterCommentQuery request, CancellationToken cancellationToken)
        {
            var param = request.FilterParams;

            var result = _context.Comments.OrderByDescending(i => i.CreationDate).AsQueryable();

            if (param.CommentStatus != null)
                result = result.Where(i => i.Status == param.CommentStatus);

            if (param.UserId != null)
                result = result.Where(i => i.UserId == param.UserId);

            if (param.StartDate != null)
                result = result.Where(i => i.CreationDate.Date >= param.StartDate.Value.Date);

            if (param.EndDate != null)
                result = result.Where(i => i.CreationDate.Date <= param.EndDate.Value.Date);

            var skip = (param.PageId - 1) * param.Take;

            var model = new CommentFilterResult()
            {
                Data = await result.Skip(skip).Take(param.Take).Select(comment => comment.Map()).ToListAsync(cancellationToken),
                FilterParams = param,
            };

            model.GeneratePaging(result, param.Take, param.PageId);

            return model;
        }
    }
}
