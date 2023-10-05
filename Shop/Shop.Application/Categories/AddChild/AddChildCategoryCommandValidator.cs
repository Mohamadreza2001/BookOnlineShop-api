using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandValidator : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandValidator()
        {
            RuleFor(i => i.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));
            RuleFor(i => i.Slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
