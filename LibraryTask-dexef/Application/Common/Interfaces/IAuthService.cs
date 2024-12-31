using LibraryTask_dexef.Shared.Models.User;

namespace LibraryTask_dexef.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<UserSignInResponse> SignIn(UserSignInRequest request);
        Task<UserSignUpResponse> SignUp(UserSignUpRequest request, CancellationToken token);
        void Logout();
        Task<string> RefreshToken();
        Task<UserProfileResponse> GetProfile();
    }
}