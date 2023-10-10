using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.SiteEntites.Slider.Create
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(i => i.ImageFile).NotNull().WithMessage(ValidationMessages.required("ImageFile")).JustImageFile();
            RuleFor(i => i.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Link"));
            RuleFor(i => i.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));
        }
    }
}
