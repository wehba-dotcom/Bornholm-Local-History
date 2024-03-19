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
           