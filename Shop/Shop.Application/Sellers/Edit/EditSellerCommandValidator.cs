using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.Sellers.Edit
{
    public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
    {
        public EditSellerCommandValidator()
        {
            RuleFor(i => i.ShopName).NotEmpty().WithMessage(ValidationMessages.required("ShopName"));
            RuleFor(i => i.NationalCode).NotEmpty().WithMessage(ValidationMessages.required("NationalCode")).ValidNationalId();
        }
    }
}
