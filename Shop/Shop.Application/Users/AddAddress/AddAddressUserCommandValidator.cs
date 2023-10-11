using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.AddAddress
{
    public class AddAddressUserCommandValidator : AbstractValidator<AddAddressUserCommand>
    {
        public AddAddressUserCommandValidator()
        {
            RuleFor(i => i.City).NotEmpty().WithMessage(ValidationMessages.required("City"));
            RuleFor(i => i.Province).NotEmpty().WithMessage(ValidationMessages.required("Province"));
            RuleFor(i => i.Name).NotEmpty().WithMessage(ValidationMessages.required("Name"));
            RuleFor(i => i.Family).NotEmpty().WithMessage(ValidationMessages.required("Family"));
            RuleFor(i => i.NationalCode).NotEmpty().WithMessage(ValidationMessages.required("NationalCode"));
            RuleFor(i => i.PostAddress).NotEmpty().WithMessage(ValidationMessages.required("PostAddress"));
            RuleFor(i => i.PostalCode).NotEmpty().WithMessage(ValidationMessages.required("PostalCode"));
        }
    }
}
