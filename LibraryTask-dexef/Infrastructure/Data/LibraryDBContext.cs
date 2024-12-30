using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryTask_dexef.Infrastructure.Data
{
    public class LibraryDBContext : IdentityDbContext<ApplicationUser, RoleIdentity, Guid,
            IdentityUserClaim<Guid>, UserRoles, IdentityUserLogin<Guid>,
            IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DbSet<Book> Books { get; set; }
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin").HasKey(l => new
            {
                l.LoginProvider,
                l.ProviderKey,
                l.UserId
            });
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            builder.Seed();
        }
    }
}
