using System;

namespace LoseCoupledMonolithic.PaymentService
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
    }
}
