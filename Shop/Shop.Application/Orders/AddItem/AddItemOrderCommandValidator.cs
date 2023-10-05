using FluentValidation;

namespace Shop.Application.Orders.AddItem
{
    public class AddItemOrderCommandValidator : AbstractValidator<AddItemOrderCommand>
    {
        public AddItemOrderCommandValidator()
        {
            RuleFor(i => i.Count).GreaterThanOrEqualTo(1).WithMessage("Count must be greater than 0");
        }
    }
}
