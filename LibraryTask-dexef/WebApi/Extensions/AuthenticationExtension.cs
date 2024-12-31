using System.Text;
using LibraryTask_dexef.Application.Common;
using LibraryTask_dexef.Domain.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace LibraryTask_dexef.WebApi.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void AddAuth(this IServiceCollection services, Identity identitySettings, bool isLocal = false)
        {
            var authenticationBuilder = services.AddAuthentication($"{JwtBearerDefaults.AuthenticationScheme}_{identitySettings.Issuer}");
            authenticationBuilder.AddJwtBearer($"{JwtBearerDefaults.AuthenticationScheme}_{identitySettings.Issuer}", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = !isLocal,
                    ValidateLifetime = !isLocal,
                    ValidateAudience = !isLocal, 
                    ValidIssuer = identitySettings.Issuer,
                    ValidAudience = identitySettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identitySettings.Key)),
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.FromMinutes(20), 
                };

                options.Authority = identitySettings.Issuer;
                options.RequireHttpsMetadata = identitySettings.ValidateHttps;
            });

            services.AddAuthorization(options =>
            {
                var authSchemes = $"{JwtBearerDefaults.AuthenticationScheme}_{identitySettings.Issuer}";
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(authSchemes)
                    .Build();

                options.AddPolicy("user_read", policy => policy.Requirements.Add(
                    new HasScopeRequirement(
                        identitySettings.ScopeBaseDomain,
                        identitySettings.ScopeBaseDomain + "/read",
                        identitySettings.Issuer)));

                options.AddPolicy("user_write", policy => policy.Requirements.Add(
                    new HasScopeRequirement(
                        identitySettings.ScopeBaseDomain,
                        identitySettings.ScopeBaseDomain + "/write",
                        identitySettings.Issuer)));
            });
        }

    }
}