using IdentityApi.Models;
namespace IdentityApi.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequest registrationRequest);
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<bool> AssignRole(string email, string roleName);
    }
}
