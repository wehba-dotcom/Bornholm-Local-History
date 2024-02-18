using Microsoft.AspNetCore.Identity;

namespace SharedModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
