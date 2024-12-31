using libraryTask_dexef.Domain.Entities;
using LibraryTask_dexef.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace LibraryTask_dexef.Domain.Entities
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
