using WebApi.Models;

namespace WebApi.Service.IService
{
    public interface IAuthService
    {
        Task<Response?> LoginAsync(LoginRequest loginRequest);
        Task<Response?> RegisterAsync(RegistrationRequest registrationRequest);
        Task<Response?> AssignRoleAsync(RegistrationRequest registrationRequest);
    }
}
