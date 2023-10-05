using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            RuleFor(i => i.Text).NotNull().MinimumLength(5).WithMessage(ValidationMessages.minLength("Text", 5));
        }
    }
}
