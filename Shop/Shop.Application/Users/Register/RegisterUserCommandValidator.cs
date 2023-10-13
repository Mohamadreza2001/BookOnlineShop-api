using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(i => i.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("Password"))
                .NotNull()
                .MinimumLength(4).WithMessage("Password should be more than 4 characters");
        }
    }

}
