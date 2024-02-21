using WebApi;
using WebApi.Models;

namespace Mango.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(OrderDto orderDto);
        Task<ResponseDto?> GetAllOrders();
        Task<ResponseDto?> GetOrder(int orderId);
       
    }
}
