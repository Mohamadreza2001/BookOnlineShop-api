using Common.Application;
using Common.Application.SecurityUtil;
using Common.CacheHelper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.ChargeWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Application.Users.RemoveToken;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.GetByFilter;
using Shop.Query.Users.GetById;
using Shop.Query.Users.GetByPhoneNumber;
using Shop.Query.Users.UserTokens.GetByJwtToken;
using Shop.Query.Users.UserTokens.GetByRefreshToken;

namespace Shop.Presentation.facade.Users
{
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public UserFacade(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        public async Task<OperationResult> AddToken(AddTokenUserCommand command)
        {
            return await _mediator.Send(command);
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
            var result = await _mediator.Send(command);
            if (result.Status == OperationResultStatus.Success)
                await _distributedCache.RemoveAsync(CacheKeys.User(command.UserId));
            return result;
        }

        public async Task<UserFilterResult> GetByFilter(UserFilterParams filterParams)
        {
            return await _mediator.Send(new GetByFilterUserQuery(filterParams));
        }

        public async Task<UserDto?> GetById(long id)
        {
            return await _distributedCache.GetOrSet(CacheKeys.User(id), () =>
            {
                return _mediator.Send(new GetByIdUserQuery(id));
            });
        }

        public async Task<UserDto?> GetByPhoneNumber(string phoneNumber)
        {
            return await _mediator.Send(new GetByPhoneNumberUserQuery(phoneNumber));
        }

        public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
        {
            var hashJwtToken = Sha256Hasher.Hash(jwtToken);
            return await _distributedCache.GetOrSet(CacheKeys.UserToken(hashJwtToken), () =>
            {
                return _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));
            });
        }

        public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
        {
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
            return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
        }

        public async Task<OperationResult> Register(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RemoveToken(RemoveTokenUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Status != OperationResultStatus.Success)
                return OperationResult.Error();
            await _distributedCache.RemoveAsync(CacheKeys.UserToken(result.Data));
            return OperationResult.Success();
        }
    }
}
