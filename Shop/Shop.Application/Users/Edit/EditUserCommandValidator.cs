using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(i => i.PhoneNumber).ValidPhoneNumber();

            RuleFor(i => i.Email).EmailAddress().WithMessage("Email is not valid");

            RuleFor(i => i.Password)
                .MinimumLength(4).WithMessage("Password should be more than 4 characters");

            RuleFor(i => i.Avatar)
                .JustImageFile();
        }
    }
}
