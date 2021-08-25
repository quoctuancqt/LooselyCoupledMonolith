using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LoseCoupledMonolithic.OrderService
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Order service!");

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] OrderContext dbContext)
        {
            var data = new Order
            {
                OrderId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid()
            };

            dbContext.Orders.Add(data);

            await dbContext.SaveChangesAsync();

            return Ok(data);
        }
    }
}
