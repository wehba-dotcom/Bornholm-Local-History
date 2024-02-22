using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApi.Models;



namespace WebApi.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly IHttpClientFactory _httpClientFactory;
      
        public OrderController(IOrderService orderService, IHttpClientFactory httpClientFactory)
        {
            _orderService = orderService;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<SharedModels.Order>? list =new ();

            ResponseDto? response = await _orderService.GetAllOrders();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<SharedModels.Order>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Order model)
        {

            //    ResponseDto? response = await _orderService.CreateOrder(model);

            //    if (response != null && response.IsSuccess)
            //    {
            //        TempData["success"] = "Coupon created successfully";
            //        return RedirectToAction(nameof(Index));
            //    }
            //    else
            //    {
            //        TempData["error"] = response?.Message;
            //    }

            //return View(model);
            try
            {
                using (var client = _httpClientFactory.CreateClient("MyClient"))
                {
                    // Serialize the Feallesbase object and send it in the request body
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    // Use Uri.EscapeUriString to ensure proper URL encoding
                    var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:8002/api/order/CreateOrder")
                    {
                        Content = content
                    };

                    var response = await client.SendAsync(request);

                    response.EnsureSuccessStatusCode(); // Ensure a successful response (status code 2xx)

                    TempData["success"] = "En annonccer tilføjet successfully";
                    return RedirectToAction("Index");
                }
            }
            catch (HttpRequestException ex)
            {
                // Log the exception or handle it appropriately
                ViewBag.Alert = $"Noget er galt! Grunden: {ex.Message}";
                return View();
            }
        }
    }
}
