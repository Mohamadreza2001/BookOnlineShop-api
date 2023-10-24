using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.RemoveToken
{
    internal class RemoveTokenUserCommandHandler : IBaseCommandHandler<RemoveTokenUserCommand>
    {
        private readonly IUserRepository _repository;

        public RemoveTokenUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveTokenUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            user.RemoveToken(request.TokenId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
