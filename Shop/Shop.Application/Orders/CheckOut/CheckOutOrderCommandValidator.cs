using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
    {
        public CheckOutOrderCommandValidator()
        {
            RuleFor(i => i.Name).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Name"));
            RuleFor(i => i.Family).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Family"));
            RuleFor(i => i.City).NotNull().NotEmpty().WithMessage(ValidationMessages.required("City"));
            RuleFor(i => i.Province).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Province"));
            RuleFor(i => i.PhoneNumber).NotNull().NotEmpty().WithMessage(ValidationMessages.required("PhoneNumber"))
                .Length(11).WithMessage("Invalid phone number");
            RuleFor(i => i.NationalCode).NotNull().NotEmpty().WithMessage(ValidationMessages.required("National code"))
                .Length(10).WithMessage("Invalid national code").ValidNationalId();
            RuleFor(i => i.PostAddress).NotNull().NotEmpty().WithMessage(ValidationMessages.required("PostAddress"));
            RuleFor(i => i.PostalCode).NotNull().NotEmpty().WithMessage(ValidationMessages.required("PostalCode"));
        }
    }
}
