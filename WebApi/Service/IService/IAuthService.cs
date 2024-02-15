using WebApi.Models;

namespace WebApi.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequest loginRequest);
        Task<ResponseDto?> RegisterAsync(RegistrationRequest registrationRequest);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequest registrationRequest);
    }
}
