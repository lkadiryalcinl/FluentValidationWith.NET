using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public static List<Order> Orders = new();

        private IValidator<Order> _validator;

        public OrdersController(IValidator<Order> validator)
        {
            _validator = validator;
        }

        [HttpGet("/GetAllOrder")]
        public IActionResult GetAll()
        {
            return Ok(Orders.ToList());
        }

        [HttpPost("/CreateOrder")]
        public async Task<IActionResult> Create(Order order)
        {
            ValidationResult result = await _validator.ValidateAsync(order);

            if (result.IsValid)
            {
                Orders.Add(order);
                return Ok("Order Successfully added.");
            }

            return BadRequest(result);
        }
    }
}
