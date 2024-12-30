using LibraryTask_dexef.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace LibraryTask_dexef.Domain.Entities
{

    public class UserRoles : IdentityUserRole<Guid>
    {
        public virtual ApplicationUser User { get; set; }

        public virtual RoleIdentity Role { get; set; }
    }
}