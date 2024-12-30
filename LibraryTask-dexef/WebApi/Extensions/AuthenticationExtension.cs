using System.Text;
using libraryTask_dexef.Application.Common;
using LibraryTask_dexef.Domain.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace LibraryTask_dexef.WebApi.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void AddAuth(this IServiceCollection services, Identity identitySettings)
        {
            var authenticationBuilder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            authenticationBuilder.AddJwtBearer($"{JwtBearerDefaults.AuthenticationScheme}_{identitySettings.Issuer}", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidIssuer = identitySettings.Issuer,
                    ValidAudience = identitySettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identitySettings.Key)),
                    ValidateIssuerSigningKey = true,
                };
                options.Authority = identitySettings.Issuer;
                options.RequireHttpsMetadata = identitySettings.ValidateHttps;
            });

            services.AddAuthorization(options =>
            {
                var authSchemes = $"{JwtBearerDefaults.AuthenticationScheme}_{identitySettings.Issuer}"; options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().AddAuthenticationSchemes(authSchemes).Build();

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
        public static void AddAuthLocal(this IServiceCollection services, Identity identitySettings)
        {
            var authenticationBuilder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            authenticationBuilder.AddJwtBearer($"{JwtBearerDefaults.AuthenticationScheme}_{identitySettings.Issuer}", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = false,
                    ValidateAudience = true,
                    ValidIssuer = identitySettings.Issuer,
                    ValidAudience = identitySettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identitySettings.Key)),
                    ValidateIssuerSigningKey = true,
                };
                options.Authority = identitySettings.Issuer;
                options.RequireHttpsMetadata = identitySettings.ValidateHttps;
            });

            services.AddAuthorization(options =>
            {
                var authSchemes = $"{JwtBearerDefaults.AuthenticationScheme}_{identitySettings.Issuer}"; options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().AddAuthenticationSchemes(authSchemes).Build();

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