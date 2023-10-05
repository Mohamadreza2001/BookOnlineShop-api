using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(i => i.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));
            RuleFor(i => i.Slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
