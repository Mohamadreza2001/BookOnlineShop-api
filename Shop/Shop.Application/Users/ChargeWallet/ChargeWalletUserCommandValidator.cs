using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeWalletUserCommandValidator : AbstractValidator<ChargeWalletUserCommand>
    {
        public ChargeWalletUserCommandValidator()
        {
            RuleFor(i => i.Description)
                .NotEmpty().WithMessage(ValidationMessages.required("Description"));

            RuleFor(i => i.Price)
                .GreaterThanOrEqualTo(1000);
        }
    }
}
