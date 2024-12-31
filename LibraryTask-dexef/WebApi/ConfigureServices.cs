using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryTask_dexef.Application.Common;
using LibraryTask_dexef.WebApi.Extensions;
using LibraryTask_dexef.WebApi.Middlewares;
using LibraryTask_dexef.Domain.Authorization;
using LibraryTask_dexef.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace LibraryTask_dexef.WebApi
{

    public static class ConfigureServices
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddAuth(appSettings.Identity,appSettings.Identity.IsLocal);
            services.AddSingleton(appSettings.Identity);
            services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            // Middleware
            services.AddSingleton<GlobalExceptionMiddleware>();

            // Extension classes
            services.AddHealthChecks();
            services.AddCompressionCustom();
            services.AddCorsCustom(appSettings);
            services.AddHttpClient();
            services.AddSwaggerOpenAPI(appSettings);

            // Json configuration
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.WriteIndented = true;
                options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            return services;
        }
    }
}