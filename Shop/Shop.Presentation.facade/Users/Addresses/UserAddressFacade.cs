using Common.Application;
using MediatR;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;

namespace Shop.Presentation.facade.Users.Addresses
{
    internal class UserAddressFacade : IUserAddressFacade
    {
        private readonly IMediator _mediator;

        public UserAddressFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddAddress(AddAddressUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteAddress(DeleteAddressUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditAddress(EditAddressUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
