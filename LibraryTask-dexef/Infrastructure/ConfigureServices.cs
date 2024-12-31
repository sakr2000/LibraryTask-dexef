using libraryTask_dexef.Application;
using libraryTask_dexef.Application.Common;
using libraryTask_dexef.Application.Repositories;
using libraryTask_dexef.Infrastructure;
using libraryTask_dexef.Infrastructure.Interface;
using LibraryTask_dexef.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryTask_dexef.Infrastructure
{

    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, AppSettings configuration)
        {

            if (configuration.UseInMemoryDatabase)
            {
                services.AddDbContext<LibraryDBContext>(options =>
                    options.UseInMemoryDatabase("LibraryDB"));
            }
            else
            {
                services.AddDbContext<LibraryDBContext>(options =>
                    options.UseSqlServer(configuration.ConnectionStrings.DefaultConnection));
            }
            services.AddIdentity<ApplicationUser, RoleIdentity>()
                    .AddEntityFrameworkStores<LibraryDBContext>()
                    .AddDefaultTokenProviders();

            // register services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}