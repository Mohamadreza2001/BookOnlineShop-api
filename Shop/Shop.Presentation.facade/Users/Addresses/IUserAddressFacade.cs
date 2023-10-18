using Common.Application;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;

namespace Shop.Presentation.facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddress(AddAddressUserCommand command);
        Task<OperationResult> DeleteAddress(DeleteAddressUserCommand command);
        Task<OperationResult> EditAddress(EditAddressUserCommand command);
    }
}
