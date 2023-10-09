using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(i => i.Title).NotEmpty().WithMessage(ValidationMessages.required("Title"));
        }
    }
}
