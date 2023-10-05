﻿using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(i => i.Text).NotNull().MinimumLength(5).WithMessage(ValidationMessages.minLength("Text", 5));
        }
    }
}
