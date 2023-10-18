using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByPhoneNumber
{
    public record GetByPhoneNumberUserQuery(string PhoneNumber) : IQuery<UserDto?>;
}
