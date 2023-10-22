using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Presentation.facade.Comments;
using Shop.Query.Comments.DTOs;

namespace Shop.Api.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentFacade _commentFacade;

        public CommentController(ICommentFacade commentFacade)
        {
            _commentFacade = commentFacade;
        }

        [HttpGet("commentId")]
        public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
        {
            return QueryResult(await _commentFacade.GetByIdComment(commentId));
        }

        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery] CommentFilterParams filterParams)
        {
            return QueryResult(await _commentFacade.GetByFilterComment(filterParams));
        }

        [HttpPost]
        public async Task<ApiResult> CreateComment(CreateCommentCommand command)
        {
            return CommandResult(await _commentFacade.Create(command));
        }

        [HttpPut]
        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {
            return CommandResult(await _commentFacade.Edit(command));
        }

        [HttpPut]
        public async Task<ApiResult> ChangeCommentStatus(ChangeStatusCommentCommand command)
        {
            return CommandResult(await _commentFacade.ChangeStatus(command));
        }
    }
}
