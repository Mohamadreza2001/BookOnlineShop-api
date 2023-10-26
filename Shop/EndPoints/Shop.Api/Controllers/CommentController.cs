using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Domain.RoleAgg.Enums;
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

        [PermissionChecker(Permission.Comment_Management)]
        [HttpGet("commentId")]
        public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
        {
            return QueryResult(await _commentFacade.GetByIdComment(commentId));
        }

        [PermissionChecker(Permission.Comment_Management)]
        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery] CommentFilterParams filterParams)
        {
            return QueryResult(await _commentFacade.GetByFilterComment(filterParams));
        }

        [Authorize]
        [HttpPost]
        public async Task<ApiResult> CreateComment(CreateCommentCommand command)
        {
            return CommandResult(await _commentFacade.Create(command));
        }

        [Authorize]
        [HttpPut]
        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {
            return CommandResult(await _commentFacade.Edit(command));
        }

        [PermissionChecker(Permission.Comment_Management)]
        [HttpPut("changeStatus")]
        public async Task<ApiResult> ChangeCommentStatus(ChangeStatusCommentCommand command)
        {
            return CommandResult(await _commentFacade.ChangeStatus(command));
        }
    }
}
