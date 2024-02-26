using Mango.Web.Service.IService;
using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class OrderService : IOrderService
    {

        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateOrder(Models.Order orderDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = orderDto,
                Url = SD.GateWayIBase + "/api/order/CreateOrder"
            });
        }

        public async Task<ResponseDto?> GetAllOrders()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.GateWayIBase + "/api/order"
            });
        }

        public async Task<ResponseDto?> GetOrder(int orderId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.GateWayIBase + "/api/order/GetOrder/" + orderId
            });
        }
    }
}
