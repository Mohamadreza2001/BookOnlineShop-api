using Common.Application;
using MediatR;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.ChargeWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.GetByFilter;
using Shop.Query.Users.GetById;
using Shop.Query.Users.GetByPhoneNumber;

namespace Shop.Presentation.facade.Users
{
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> ChargeWallet(ChargeWalletUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserFilterResult> GetByFilter(UserFilterParams filterParams)
        {
            return await _mediator.Send(new GetByFilterUserQuery(filterParams));
        }

        public async Task<UserDto?> GetById(long id)
        {
            return await _mediator.Send(new GetByIdUserQuery(id));
        }

        public async Task<UserDto?> GetByPhoneNumber(string phoneNumber)
        {
            return await _mediator.Send(new GetByPhoneNumberUserQuery(phoneNumber));
        }

        public async Task<OperationResult> Register(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
