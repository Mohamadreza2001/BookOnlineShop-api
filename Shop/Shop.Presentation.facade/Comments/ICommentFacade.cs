using Common.Application;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTOs;

namespace Shop.Presentation.facade.Comments
{
    public interface ICommentFacade
    {
        Task<OperationResult> ChangeStatus(ChangeStatusCommentCommand command);
        Task<OperationResult> Create(CreateCommentCommand command);
        Task<OperationResult> Edit(EditCommentCommand command);

        Task<CommentDto?> GetByIdComment(long id);
        Task<CommentFilterResult> GetByFilterComment(CommentFilterParams filterParams);
    }
}
