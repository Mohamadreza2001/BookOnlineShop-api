using FluentValidation;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseItemCountOrderCommandValidator:AbstractValidator<DecreaseItemCountOrderCommand>
    {
        public DecreaseItemCountOrderCommandValidator()
        {
            RuleFor(i => i.Count).GreaterThanOrEqualTo(1).WithMessage("Count must be greater than 0");
        }
    }
}
