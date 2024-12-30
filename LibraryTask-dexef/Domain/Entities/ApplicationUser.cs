using Microsoft.AspNetCore.Identity;

namespace LibraryTask_dexef.Domain.Entities
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public string Name { get; set; }
    }
}
