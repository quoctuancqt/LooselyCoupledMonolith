using System;

namespace OrderService.Contract
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
