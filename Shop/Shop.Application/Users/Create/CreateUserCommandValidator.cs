using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(i => i.PhoneNumber).ValidPhoneNumber();

            RuleFor(i => i.Email).EmailAddress().WithMessage("Email is not valid");

            RuleFor(i => i.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("Password"))
                .NotNull()
                .MinimumLength(4).WithMessage("Password should be more than 4 characters");
        }
    }
}
