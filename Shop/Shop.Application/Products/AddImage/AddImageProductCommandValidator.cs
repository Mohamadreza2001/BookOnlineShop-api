using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddImageProductCommandValidator : AbstractValidator<AddImageProductCommand>
    {
        public AddImageProductCommandValidator()
        {
            RuleFor(i => i.ImageFile).NotNull().WithMessage(ValidationMessages.required("Picture")).JustImageFile();
            RuleFor(i => i.Sequence).GreaterThanOrEqualTo(0);
        }
    }
}
