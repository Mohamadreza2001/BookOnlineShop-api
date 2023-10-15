using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter
{
    public class GetByFilterCommentQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
    {
        public GetByFilterCommentQuery(CommentFilterParams filterParam) : base(filterParam)
        {
        }
    }
}
