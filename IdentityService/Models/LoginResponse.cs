using IdentityApi.Models;

namespace IdentityApi.Models
{
    public class LoginResponse
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
