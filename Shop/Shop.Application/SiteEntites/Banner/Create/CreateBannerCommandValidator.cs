using Common.Application.Validation;
using Common.Application.Validation.FluentValidation;
using FluentValidation;

namespace Shop.Application.SiteEntites.Banner.Create
{
    public class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommand>
    {
        public CreateBannerCommandValidator()
        {
            RuleFor(i => i.ImageFile).NotNull().WithMessage(ValidationMessages.required("ImageFile")).JustImageFile();
            RuleFor(i => i.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Link"));
        }
    }
}
