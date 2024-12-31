using LibraryTask_dexef.Application.Common;
using LibraryTask_dexef.Application.Common.Interfaces;
using LibraryTask_dexef.Application.Common.Utilities;
using LibraryTask_dexef.Application.Services;

namespace LibraryTask_dexef.Application
{

    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, AppSettings appsettings)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowedBooksService, BorrowedBookService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthIdentityService, AuthIdentityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrentTime, CurrentTime>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICookieService, CookieService>();

            return services;
        }
    }
}