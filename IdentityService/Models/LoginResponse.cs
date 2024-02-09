using IdentityService.Models;

namespace IdentityService.Models
{
    public class LoginResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
