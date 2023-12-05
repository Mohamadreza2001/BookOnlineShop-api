using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.RemoveToken
{
    internal class RemoveTokenUserCommandHandler : IBaseCommandHandler<RemoveTokenUserCommand, string>
    {
        private readonly IUserRepository _repository;

        public RemoveTokenUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<string>> Handle(RemoveTokenUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult<string>.NotFound();
            var result = user.RemoveToken(request.TokenId);
            await _repository.Save();
            return OperationResult<string>.Success(result);
        }
    }
}
