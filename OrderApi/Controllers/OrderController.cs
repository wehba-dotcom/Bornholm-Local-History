using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Data;
using OrderApi.Infrastructure;
using OrderApi.Models;
using SharedModels;

namespace OrderApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
        {
            private readonly IConfiguration _configuration;
            private readonly OrderApiContext _context;
            private readonly IRepository<Order> repository;
            private IMapper _mapper;
            private readonly IConverter<Order, OrderDto> orderConverter;
            private IMessagePublisher messagePublisher;
             IServiceGateway<ProductDto> productServiceGateway;
         
            
        public OrderController(
                 IConfiguration configuration,
                OrderApiContext context,
                IMapper mapper,
                IRepository<Order> repos,
                IConverter<Order, OrderDto> orderConverter,
                IServiceGateway<ProductDto> productServiceGateway,
                IMessagePublisher publisher)
            {
               _configuration = configuration;
                repository = repos;
                this.orderConverter = orderConverter;
                productServiceGateway = productServiceGateway;
                messagePublisher = publisher;
                _mapper = mapper;
                _context = context;
                
            }

            // GET: orders
            [HttpGet]
            public async Task<IEnumerable<Order>> GetAsync()
            {
                return await repository.GetAllAsync();
            }

            // GET orders/5
            [HttpGet("{ID}", Name = "GetOrder")]
            public async Task<IActionResult> GetAsync(int ID)
            {
                var item = await repository.GetAsync(ID);
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
            public async Task<IEnumerable<Order>> GetByProduct(int ID)
            {
                List<Order> ordersWithSpecificProduct = new List<Order>();
                var allorders = await repository.GetAllAsync();
                foreach (var order in allorders)
                {
                    if (order.OrderLines.Where(o => o.ProductId == ID).Any())
                    {
                        ordersWithSpecificProduct.Add(order);
                    }
                }

                return ordersWithSpecificProduct;
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
            
                    if (order.CustomerId == null )
                        {
                            return StatusCode(500, "Customer does not exist");
                        }
              
                    try
                    {
                    // Publish OrderStatusChangedMessage. If this operation
                    // fails, the order will not be created
                  
                        string topicName = _configuration.GetValue<string>("TopicAndQueueNames:OrderCreatedTopic");
                   
                        messagePublisher.PublishOrderStatusChangedMessage( order.OrderLines, topicName);

                        order.Status = OrderDto.OrderStatus.completed;
                        var newOrder = await repository.AddAsync(orderConverter.Convert(order));
                        return CreatedAtRoute("GetOrder", new { id = newOrder.Id }, newOrder);
               

                   
                    }
                    catch
                    {
                        return StatusCode(500, "An error happened. Try again.");
                    }


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
