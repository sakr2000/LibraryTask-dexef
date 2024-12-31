using LibraryTask_dexef.Application;
using LibraryTask_dexef.Application.Common;
using LibraryTask_dexef.WebApi.Extensions;
using LibraryTask_dexef.WebApi.Middlewares;
using LibraryTask_dexef.Infrastructure;

namespace LibraryTask_dexef.WebApi.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder, AppSettings appsettings)
        {
            builder.Services.AddInfrastructuresService(appsettings);
            builder.Services.AddApplicationService(appsettings);
            builder.Services.AddWebAPIService(appsettings);

            return builder.Build();
        }

        public static async Task<WebApplication> ConfigurePipelineAsync(this WebApplication app, AppSettings appsettings)
        {
            using var loggerFactory = LoggerFactory.Create(builder => { });
            using var scope = app.Services.CreateScope();

            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.ConfigureExceptionHandler(loggerFactory.CreateLogger("Exceptions"));
            app.UseMiddleware<LoggingMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigin");
            app.UseSwagger(appsettings);
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }

    }
}