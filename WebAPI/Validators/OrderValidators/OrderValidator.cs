using FluentValidation;
using WebAPI.Models;
using WebAPI.Validators.ProductValidators;

namespace WebAPI.Validators.OrderValidators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator() 
        {
            RuleFor(x => x.CustomerName)
                .NotNull().WithMessage("Order customerName cannot be empty.")
                .MinimumLength(5).WithMessage("Order customerName length should be greater than 5 chars")
                .MaximumLength(30).WithMessage("Order customerName length should be less than 30 chars");

            RuleForEach(x => x.Products).SetValidator(new ProductValidator());
        }
    }
}
