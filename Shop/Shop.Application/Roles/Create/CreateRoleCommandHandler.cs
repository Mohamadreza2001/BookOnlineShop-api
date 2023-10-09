using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Create
{
    internal class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public CreateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(i =>
            {
                permissions.Add(new RolePermission(i));
            });
            var role = new Role(request.Title, permissions);
            _repository.Add(role);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
