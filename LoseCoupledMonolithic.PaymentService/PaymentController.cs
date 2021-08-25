using Microsoft.AspNetCore.Mvc;
using OrderService.Contract;
using System.Threading.Tasks;

namespace LoseCoupledMonolithic.PaymentService
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Payment Service!");

        [HttpPost("order:create")]
        public async Task<IActionResult> CreateOrder([FromServices] IOrderClient orderClient, [FromServices] PaymentContext dbContext)
        {
            var response = await orderClient.CreateAsync();

            var payment = new Payment
            {
                OrderId = response.OrderId
            };

            dbContext.Payments.Add(payment);

            await dbContext.SaveChangesAsync();

            return Ok(response);
        }
    }
}
