using DocumentFormat.OpenXml.Wordprocessing;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Monitoring;
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
            MonitorService.Log.Here().Debug(" Intered First Create Meethod in OrderController WebApi");
            List<SharedModels.Order>? list = new();

            ResponseDto? response = await _orderService.GetAllOrders();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<SharedModels.Order>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            MonitorService.Log.Here().Debug("return List on Index Method On WebApi OrderController{list}", list);
            return View(list);
        }

        public IActionResult Create()
        {
            MonitorService.Log.Here().Debug(" Intered First Create Meethod in OrderController WebApi");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Order model)
        {
            MonitorService.Log.Here().Debug("We Intered HttpPost Create Meethod in OrderController WebApi");
            ResponseDto? response = await _orderService.CreateOrder(model);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon created successfully";
                return RedirectToAction(nameof(Index));
                MonitorService.Log.Here().Debug("We Finished The Create Meethod in OrderController WebApi");
            }
            else
            {

                TempData["error"] = response?.Message;
                MonitorService.Log.Here().Error(" An Error Occured on Create Method on OrderController WebApi :{response?.Message}", response?.Message);
            }

            return View(model);

        }
    }
}
            //try
            //{
            //    MonitorService.Log.Here().Debug(" Intered Create Meethod in OrderController WebApi");
            //    using (var client = _httpClientFactory.CreateClient("MyClient"))
            //    {
            //        // Serialize the Feallesbase object and send it in the request body
            //        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            //        // Use Uri.EscapeUriString to ensure proper URL encoding
            //        var request = new HttpRequestMessage(HttpMethod.Post, $"http://order-api/api/order/CreateOrder")
            //        {
            //            Content = content
            //        };

            //        var response = await client.SendAsync(request);
            //        MonitorService.Log.Here().Debug(" Return Obj {response}", response);
            //        response.EnsureSuccessStatusCode(); // Ensure a successful response (status code 2xx)

            //        TempData["success"] = "En annonccer tilføjet successfully";
            //        return RedirectToAction("Index");
            //    }
            //}
            //catch (HttpRequestException ex)
            //{
            //    MonitorService.Log.Here().Error(" An Error Occured on Create Method on OrderController WebApi :{message}",ex.Message);
            //    // Log the exception or handle it appropriately
            //    ViewBag.Alert = $"Noget er galt! Grunden: {ex.Message}";
            //    return View();
            //}
  