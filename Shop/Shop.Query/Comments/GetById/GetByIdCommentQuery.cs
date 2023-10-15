using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById
{
    public record GetByIdCommentQuery(long CommentId) : IQuery<CommentDto?>;
}
