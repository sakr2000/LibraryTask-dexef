﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LibraryTask_dexef.Domain.Entities
{
    [NotMapped]
    public class RoleIdentity : IdentityRole<Guid>
    {
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
