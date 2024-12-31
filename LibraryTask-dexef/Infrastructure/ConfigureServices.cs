using LibraryTask_dexef.Application;
using LibraryTask_dexef.Application.Common;
using LibraryTask_dexef.Application.Repositories;
using LibraryTask_dexef.Infrastructure;
using LibraryTask_dexef.Infrastructure.Interface;
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
            services.AddScoped<IBorrowedBooksRepository, BorrowedBooksRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}