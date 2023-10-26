using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.facade.Roles;
using Shop.Query.Roles.DTOs;

namespace Shop.Api.Controllers
{
    [PermissionChecker(Permission.Role_Management)]
    public class RoleController : ApiController
    {
        private readonly IRoleFacade _roleFacade;

        public RoleController(IRoleFacade roleFacade)
        {
            _roleFacade = roleFacade;
        }

        [HttpGet("{roleId}")]
        public async Task<ApiResult<RoleDto?>> GetRoleById(long roleId)
        {
            return QueryResult(await _roleFacade.GetById(roleId));
        }

        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetRoleList()
        {
            return QueryResult(await _roleFacade.GetList());
        }

        [HttpPost]
        public async Task<ApiResult> CreateRole(CreateRoleCommand command)
        {
            return CommandResult(await _roleFacade.Create(command));
        }

        [HttpPut]
        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            return CommandResult(await _roleFacade.Edit(command));
        }
    }
}
