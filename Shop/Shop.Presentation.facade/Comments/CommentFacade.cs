using Common.Application;
using MediatR;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.GetByFilter;
using Shop.Query.Comments.GetById;

namespace Shop.Presentation.facade.Comments
{
    internal class CommentFacade : ICommentFacade
    {
        private readonly IMediator _mediator;

        public CommentFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> ChangeStatus(ChangeStatusCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<CommentFilterResult> GetByFilterComment(CommentFilterParams filterParams)
        {
            return await _mediator.Send(new GetByFilterCommentQuery(filterParams));
        }

        public async Task<CommentDto?> GetByIdComment(long id)
        {
            return await _mediator.Send(new GetByIdCommentQuery(id));
        }
    }
}
