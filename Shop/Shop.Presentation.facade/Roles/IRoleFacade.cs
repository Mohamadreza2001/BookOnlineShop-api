using Common.Application;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Query.Roles.DTOs;

namespace Shop.Presentation.facade.Roles
{
    public interface IRoleFacade
    {
        Task<OperationResult> Create(CreateRoleCommand command);
        Task<OperationResult> Edit(EditRoleCommand command);

        Task<RoleDto?> GetById(long id);
        Task<List<RoleDto>> GetList();
    }
}
