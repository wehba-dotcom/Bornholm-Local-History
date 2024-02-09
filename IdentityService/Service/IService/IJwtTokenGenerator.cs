using IdentityService.Data;
using IdentityService.Models;

namespace IdentityService.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
