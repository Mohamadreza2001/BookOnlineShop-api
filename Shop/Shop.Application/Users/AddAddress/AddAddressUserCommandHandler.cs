using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddAddress
{
    internal class AddAddressUserCommandHandler : IBaseCommandHandler<AddAddressUserCommand>
    {
        private readonly IUserRepository _repository;

        public AddAddressUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddAddressUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            var address = new UserAddress(request.Province, request.City, request.PostalCode, request.PostAddress,
                request.Name, request.Family, request.NationalCode, request.PhoneNumber);
            user.AddAddress(address);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
