using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById
{
    internal class GetByIdCommentQueryHandler : IQueryHandler<GetByIdCommentQuery, CommentDto?>
    {
        private readonly ShopContext _context;

        public GetByIdCommentQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CommentDto?> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(i => i.Id == request.CommentId, cancellationToken);
            if (comment == null)
                return null;
            return comment.Map();
        }
    }
}
