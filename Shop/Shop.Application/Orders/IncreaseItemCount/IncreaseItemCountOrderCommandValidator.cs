using FluentValidation;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseItemCountOrderCommandValidator : AbstractValidator<IncreaseItemCountOrderCommand>
    {
        public IncreaseItemCountOrderCommandValidator()
        {
            RuleFor(i => i.Count).GreaterThanOrEqualTo(1).WithMessage("Count must be greater than 0");
        }
    }
}
