using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            List<Order>? list =new ();

            ResponseDto? response = await _orderService.GetAllOrders();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Order>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }
    }
}
