using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Product> Products = new();

        private IValidator<Product> _validator;

        public ProductsController(IValidator<Product> validator)
        {
            _validator = validator;
        }

        [HttpGet("/GetAllProduct")]
        public IActionResult GetAll()
        {
            return Ok(Products.ToList());
        }

        [HttpPost("/CreateProduct")]
        public async Task<IActionResult> Create(Product product)
        {
            ValidationResult result = await _validator.ValidateAsync(product);

            if(result.IsValid)
            {
                Products.Add(product);
                return Ok("Product Successfully added.");
            }

            return BadRequest(result);
        }
    }
}
