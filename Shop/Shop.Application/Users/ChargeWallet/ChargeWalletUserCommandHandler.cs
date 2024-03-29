﻿using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ChargeWallet
{
    internal class ChargeWalletUserCommandHandler : IBaseCommandHandler<ChargeWalletUserCommand>
    {
        private readonly IUserRepository _repository;

        public ChargeWalletUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ChargeWalletUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            var wallet = new Wallet(request.Price, request.Description, request.IsFinally, request.Type);
            user.ChargeWallet(wallet);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
