using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
