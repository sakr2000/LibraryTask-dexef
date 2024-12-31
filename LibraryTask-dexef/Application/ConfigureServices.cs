using libraryTask_dexef.Application.Common;
using libraryTask_dexef.Application.Common.Interfaces;
using libraryTask_dexef.Application.Common.Utilities;
using libraryTask_dexef.Application.Services;

namespace libraryTask_dexef.Application
{

    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, AppSettings appsettings)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBookService, BookService>();
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