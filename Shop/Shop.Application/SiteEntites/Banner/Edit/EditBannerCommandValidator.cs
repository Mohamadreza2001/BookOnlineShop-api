using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.SiteEntites.Banner.Edit
{
    public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
    {
        public EditBannerCommandValidator()
        {
            RuleFor(i => i.ImageFile).JustImageFile();
            RuleFor(i => i.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Link"));
        }
    }
}
