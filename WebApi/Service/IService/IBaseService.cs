using WebApi.Models;

namespace WebApi.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto request, bool withBearer = true);
    }
}
