using IdentityApi.Data;
using IdentityApi.Models;

namespace IdentityApi.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
