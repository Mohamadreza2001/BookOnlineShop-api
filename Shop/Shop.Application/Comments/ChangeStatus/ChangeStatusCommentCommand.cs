using Common.Application;
using FluentValidation;
using Shop.Domain.CommentAgg.Enums;
using System.Runtime.CompilerServices;

namespace Shop.Application.Comments.ChangeStatus
{
    public record ChangeStatusCommentCommand(long CommentId, CommentStatus Status) : IBaseCommand;
}
