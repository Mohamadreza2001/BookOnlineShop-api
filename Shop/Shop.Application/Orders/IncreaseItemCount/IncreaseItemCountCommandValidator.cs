using FluentValidation;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseItemCountCommandValidator : AbstractValidator<IncreaseItemCountCommand>
    {
        public IncreaseItemCountCommandValidator()
        {
            RuleFor(i => i.Count).GreaterThanOrEqualTo(1).WithMessage("Count must be greater than 0");
        }
    }
}
