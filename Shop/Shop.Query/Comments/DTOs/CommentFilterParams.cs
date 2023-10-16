using Common.Query.Filter;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Query.Comments.DTOs
{
    public class CommentFilterParams : BaseFilterParam
    {
        public long? UserId { set; get; }
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        public CommentStatus? CommentStatus { get; set; }
    }
}
