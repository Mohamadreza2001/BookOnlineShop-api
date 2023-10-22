using Common.Application;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<AddressDto?> GetById(long userAddressId);
        Task<List<AddressDto>> GetList(long userId);

        Task<OperationResult> AddAddress(AddAddressUserCommand command);
        Task<OperationResult> DeleteAddress(DeleteAddressUserCommand command);
        Task<OperationResult> EditAddress(EditAddressUserCommand command);
    }
}
