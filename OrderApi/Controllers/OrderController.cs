﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Data;
using OrderApi.Infrastructure;
using OrderApi.Models;
using SharedModels;

namespace OrderApi.Controllers
{
   
        [ApiController]
        [Route("api/order")]
        [Authorize]
        public class OrderController : ControllerBase
        {
            private readonly IRepository<Order> repository;

            private readonly IConverter<Order, OrderDto> orderConverter;
            private IMessagePublisher messagePublisher;
            IServiceGateway<ProductDto> productServiceGateway;
            IServiceGateway<CustomerDto> customerServiceGateway;

            public OrderController(
                IRepository<Order> repos,
                IConverter<Order, OrderDto> orderConverter,
                IServiceGateway<ProductDto> gateway,
                IServiceGateway<CustomerDto> customerGateway,
                IMessagePublisher publisher)
            {
                repository = repos;
                this.orderConverter = orderConverter;
                productServiceGateway = gateway;
                customerServiceGateway = customerGateway;
                messagePublisher = publisher;

            }

            // GET: orders
            [HttpGet]
            public async Task<IEnumerable<Order>> GetAsync()
            {
                return await repository.GetAllAsync();
            }

            // GET orders/5
            [HttpGet("{id}", Name = "GetOrder")]
            public async Task<IActionResult> GetAsync(int id)
            {
                var item = await repository.GetAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
            // GET orders/product/5
            // This action method was provided to support request aggregate
            // "Orders by product" in OnlineRetailerApiGateway.
            [HttpGet("product/{id}", Name = "GetOrderByProduct")]
            public async Task<IEnumerable<Order>> GetByProduct(int id)
            {
                List<Order> ordersWithSpecificProduct = new List<Order>();
                var allorders = await repository.GetAllAsync();
                foreach (var order in allorders)
                {
                    if (order.OrderLines.Where(o => o.ProductId == id).Any())
                    {
                        ordersWithSpecificProduct.Add(order);
                    }
                }

                return ordersWithSpecificProduct;
            }
            // This action method was provided to support request aggregate
            // "Orders by customer" in OnlineRetailerApiGateway.
            [HttpGet("customer/{id}", Name = "GetOrderByCustomer")]
            public async Task<IEnumerable<Order>> GetByCustomer(int id)
            {
                List<Order> ordersWithSpecificCustomer = new List<Order>();
                var allorders = await repository.GetAllAsync();
                foreach (var order in allorders)
                {
                    if (order.CustomerId == id)
                    {
                        ordersWithSpecificCustomer.Add(order);
                    }
                }
                return ordersWithSpecificCustomer;
            }
            // POST orders
            [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody] Order hiddenOrder)
            {
                if (hiddenOrder == null)
                {
                    return BadRequest();
                }
                OrderDto order = orderConverter.Convert(hiddenOrder);

                if (order.CustomerId == null || !await CustomerExists((int)order.CustomerId))
                {
                    return StatusCode(500, "Customer does not exist");
                }
                if (!await CustomerHasGoodCreditStanding((int)order.CustomerId))
                {
                    return StatusCode(500, "Customer has unpaid orders");
                }


                if (await ProductItemsAvailable(order))
                {
                    try
                    {
                        // Publish OrderStatusChangedMessage. If this operation
                        // fails, the order will not be created
                        messagePublisher.PublishOrderStatusChangedMessage(
                            order.CustomerId, order.OrderLines, "completed");

                        // Create order.
                        order.Status = OrderDto.OrderStatus.completed;
                        var newOrder = await repository.AddAsync(orderConverter.Convert(order));
                        return CreatedAtRoute("GetOrder", new { id = newOrder.Id }, newOrder);
                    }
                    catch
                    {
                        return StatusCode(500, "An error happened. Try again.");
                    }
                }
                else
                {
                    // If there are not enough product items available.
                    return StatusCode(500, "Not enough items in stock.");
                }




            }

            private async Task<bool> CustomerExists(int customerId)
            {
                var customer = await customerServiceGateway.GetAsync(customerId);
                if (customer == null)
                { return false; }
                return true;
            }

        private async Task<bool> CustomerHasGoodCreditStanding(int customerId)
        {
            var customer = await customerServiceGateway.GetAsync(customerId);
            return customer.HasGoodCreditStanding;
        }

        private async Task<bool> ProductItemsAvailable(OrderDto order)
            {
                foreach (var orderLine in order.OrderLines)
                {
                    // Call product service to get the product ordered.
                    var orderedProduct = await productServiceGateway.GetAsync(orderLine.ProductId);
                    if (orderLine.Quantity > orderedProduct.ItemsInStock - orderedProduct.ItemsReserved)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
}
