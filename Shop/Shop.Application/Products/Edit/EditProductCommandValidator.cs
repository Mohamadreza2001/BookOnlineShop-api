using Common.Application.Validation.FluentValidation;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(i => i.Title).NotEmpty().WithMessage(ValidationMessages.required("Title"));
            RuleFor(i => i.Description).NotEmpty().WithMessage(ValidationMessages.required("Description"));
            RuleFor(i => i.Slug).NotEmpty().WithMessage(ValidationMessages.required("Slug"));
            RuleFor(i => i.ImageFile).JustImageFile();
        }
    }
}
