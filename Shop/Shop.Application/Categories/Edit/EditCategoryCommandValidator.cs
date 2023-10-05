using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(i => i.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));
            RuleFor(i => i.Slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
