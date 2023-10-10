using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.SiteEntites.Slider.Edit
{
    public class EditSliderCommandValidator : AbstractValidator<EditSliderCommand>
    {
        public EditSliderCommandValidator()
        {
            RuleFor(i => i.ImageFile).JustImageFile();
            RuleFor(i => i.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Link"));
            RuleFor(i => i.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));
        }
    }
}
