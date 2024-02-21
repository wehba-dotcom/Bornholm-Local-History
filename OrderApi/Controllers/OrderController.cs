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
           // IServiceGateway<ApplicationUser> customerServiceGateway;
            
        public OrderController(
                 IConfiguration configuration,
                OrderApiContext context,
                IMapper mapper,
                IRepository<Order> repos,
                IConverter<Order, OrderDto> orderConverter,
                IServiceGateway<ProductDto> productServiceGateway,
              //  IServiceGateway<ApplicationUser> customerGateway,
                IMessagePublisher publisher)
            {
               _configuration = configuration;
                repository = repos;
                this.orderConverter = orderConverter;
                productServiceGateway = productServiceGateway;
               // customerServiceGateway = customerGateway;
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
            // This action method was provided to support request aggregate
            // "Orders by customer" in OnlineRetailerApiGateway.
            [HttpGet("customer/{Id}", Name = "GetOrderByCustomer")]
            //public async Task<IEnumerable<Order>> GetByCustomer(int Id)
            //{
            //    List<Order> ordersWithSpecificCustomer = new List<Order>();
            //    var allorders = await repository.GetAllAsync();
            //    foreach (var order in allorders)
            //    {
            //        if (order.CustomerId == Id)
            //        {
            //            ordersWithSpecificCustomer.Add(order);
            //        }
            //    }
            //    return ordersWithSpecificCustomer;
            //}
            // POST orders
            [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody] Order hiddenOrder)
            {
                if (hiddenOrder == null)
                {
                    return BadRequest();
                }
             OrderDto order = orderConverter.Convert(hiddenOrder);

            //OrderDto order = _mapper.Map<OrderDto>(hiddenOrder);
            //order.Date= DateTime.Now;
            //order.Status = (OrderDto.OrderStatus)hiddenOrder.Status;
            //order.OrderLines = (IList<SharedModels.OrderLine>)_mapper.Map<IEnumerable<OrderLinesDto>>(hiddenOrder.OrderLines);
            
            if (order.CustomerId == null )
                {
                    return StatusCode(500, "Customer does not exist");
                }
                //if (!await CustomerHasGoodCreditStanding(order.CustomerId))
                //{
                //    return StatusCode(500, "Customer has unpaid orders");
                //}


                //if (await ProductItemsAvailable(order))
                //{
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
                //}
                //else
                //{
                //    // If there are not enough product items available.
                //    return StatusCode(500, "Not enough items in stock.");
                //}




            }

            //private async Task<bool> CustomerExists(string customerId)
            //{
            //    var customer = await customerServiceGateway.GetAsync(customerId);
            //    if (customer == null)
            //    { return false; }
            //    return true;
            //}

        //private async Task<bool> CustomerHasGoodCreditStanding(int customerId)
        //{
        //    var customer = await customerServiceGateway.GetAsync(customerId);
        //    return customer.HasGoodCreditStanding;
        //}

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
