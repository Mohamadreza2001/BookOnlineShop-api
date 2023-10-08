using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(i => i.Title).NotEmpty().WithMessage(ValidationMessages.required("Title"));
            RuleFor(i => i.Description).NotEmpty().WithMessage(ValidationMessages.required("Description"));
            RuleFor(i => i.Slug).NotEmpty().WithMessage(ValidationMessages.required("Slug"));
            RuleFor(i => i.ImageFile).JustImageFile();
        }
    }
}
