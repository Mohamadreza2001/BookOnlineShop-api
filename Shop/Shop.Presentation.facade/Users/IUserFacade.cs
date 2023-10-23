using Common.Application;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.ChargeWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.facade.Users
{
    public interface IUserFacade
    {
        Task<OperationResult> ChargeWallet(ChargeWalletUserCommand command);
        Task<OperationResult> Create(CreateUserCommand command);
        Task<OperationResult> Edit(EditUserCommand command);
        Task<OperationResult> Register(RegisterUserCommand command);
        Task<OperationResult> AddToken(AddTokenUserCommand command);

        Task<UserFilterResult> GetByFilter(UserFilterParams filterParams);
        Task<UserDto?> GetById(long id);
        Task<UserDto?> GetByPhoneNumber(string phoneNumber);
    }
}
