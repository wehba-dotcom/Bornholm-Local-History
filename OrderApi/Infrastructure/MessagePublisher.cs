using System;
using System.Collections.Generic;
using System.Diagnostics;
using EasyNetQ;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry;
using SharedModels;
using Monitoring;


namespace OrderApi.Infrastructure
{
    public class MessagePublisher : IMessagePublisher, IDisposable
    {
        IBus bus;

        public MessagePublisher(string connectionString)
        {
            bus = RabbitHutch.CreateBus(connectionString);
        }

        public void Dispose()
        {
            bus.Dispose();
        }

        public void PublishOrderStatusChangedMessage( IList<OrderLine> orderLines, string topic)
        {

            var message = new OrderStatusChangedMessage
            { 
                
                OrderLines = orderLines 
            };
           

            bus.PubSub.Publish(message, topic);
        }

    }
}
