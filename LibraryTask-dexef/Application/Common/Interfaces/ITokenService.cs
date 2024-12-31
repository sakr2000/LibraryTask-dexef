
using LibraryTask_dexef.Shared.Models.AuthIdentity.UsersIdentity;
using System.Security.Claims;

namespace LibraryTask_dexef.Application.Common.Interfaces
{

    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
        ClaimsPrincipal ValidateToken(string token);
        Task<TokenResult> GenerateToken(ApplicationUser user, string[] scopes, CancellationToken cancellationToken);
    }
}