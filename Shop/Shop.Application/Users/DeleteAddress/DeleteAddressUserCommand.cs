using Common.Application;

namespace Shop.Application.Users.DeleteAddress
{
    public record DeleteAddressUserCommand(long UserId, long AddressId) : IBaseCommand;
}
