using Common.Application;

namespace Shop.Application.Users.RemoveToken
{
    public record RemoveTokenUserCommand(long UserId, long TokenId) : IBaseCommand<string>;
}
