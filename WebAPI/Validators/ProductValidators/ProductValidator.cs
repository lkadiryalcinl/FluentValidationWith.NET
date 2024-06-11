using FluentValidation;
using WebAPI.Models;

namespace WebAPI.Validators.ProductValidators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Product name cannot be empty.")
                .MinimumLength(5).WithMessage("Product name length should be greater than 5 chars")
                .MaximumLength(30).WithMessage("Product name length should be less than 30 chars");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("Product description cannot be empty.")
                .MinimumLength(5).WithMessage("Product description length should be greater than 5 chars")
                .MaximumLength(30).WithMessage("Product description length should be less than 30 chars");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("Product price cannot be empty.")
                .GreaterThan(0).WithMessage("Product price should be greater than 0.");

            RuleFor(x => x.StockAmount)
                .NotNull().WithMessage("Product stockAmount cannot be empty.")
                .GreaterThanOrEqualTo(0).WithMessage("Product stockAmount should be greater than or equal to 0");
        }
    }
}
