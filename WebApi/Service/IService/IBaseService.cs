using WebApi.Models;

namespace WebApi.Service.IService
{
    public interface IBaseService
    {
        Task<Response?> SendAsync(Request request, bool withBearer = true);
    }
}
