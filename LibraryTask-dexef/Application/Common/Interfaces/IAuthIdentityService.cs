

using LibraryTask_dexef.Shared.Models.AuthIdentity.UsersIdentity;

namespace libraryTask_dexef.Application.Common.Interfaces
{

    public interface IAuthIdentityService
    {
        Task LogOut();
        Task<TokenResult> RefreshTokenAsync(string token, CancellationToken cancellationToken);
        Task<TokenResult> Authenticate(LoginRequest request, CancellationToken cancellationToken);
        Task Register(RegisterRequest request, CancellationToken cancellationToken);
        Task<UserViewModel> Get(CancellationToken cancellationToken);
    }
}