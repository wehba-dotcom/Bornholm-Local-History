using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
