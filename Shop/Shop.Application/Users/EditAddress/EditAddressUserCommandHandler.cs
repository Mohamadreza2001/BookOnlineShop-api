using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress
{
    internal class EditAddressUserCommandHandler : IBaseCommandHandler<EditAddressUserCommand>
    {
        private readonly IUserRepository _repository;

        public EditAddressUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditAddressUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            var address = new UserAddress(request.Province, request.City, request.PostalCode, request.PostAddress,
                request.Name, request.Family, request.NationalCode, request.PhoneNumber);
            user.EditAddress(address, request.AddressId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
