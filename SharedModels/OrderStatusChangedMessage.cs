using System.Collections.Generic;

namespace SharedModels
{
    public class OrderStatusChangedMessage
    {
        public string? CustomerId { get; set; }
        public IList<OrderLine> OrderLines { get; set; }
    }
}
