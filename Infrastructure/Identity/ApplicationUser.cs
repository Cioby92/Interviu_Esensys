using Microsoft.AspNetCore.Identity;

namespace Essensys.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string CNP { get; set; }
    }
}
