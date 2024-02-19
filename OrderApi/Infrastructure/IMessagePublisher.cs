using System.Collections.Generic;
using SharedModels;

namespace OrderApi.Infrastructure
{
    public interface IMessagePublisher
    {
        void PublishOrderStatusChangedMessage(string? customerId,
            IList<OrderLine> orderLines, string topic);
    }
}
