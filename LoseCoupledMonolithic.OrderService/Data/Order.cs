using System;

namespace LoseCoupledMonolithic.OrderService
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
