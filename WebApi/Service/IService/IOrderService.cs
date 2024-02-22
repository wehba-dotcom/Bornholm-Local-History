using WebApi;
using WebApi.Models;
using WebApi.SharedModels;

namespace Mango.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(WebApi.Models.Order orderDto);
        Task<ResponseDto?> GetAllOrders();
        Task<ResponseDto?> GetOrder(int orderId);
       
    }
}
