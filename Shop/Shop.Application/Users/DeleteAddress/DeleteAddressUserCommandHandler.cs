using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.DeleteAddress
{
    internal class DeleteAddressUserCommandHandler : IBaseCommandHandler<DeleteAddressUserCommand>
    {
        private readonly IUserRepository _repository;

        public DeleteAddressUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteAddressUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            user.DeleteAddress(request.AddressId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
