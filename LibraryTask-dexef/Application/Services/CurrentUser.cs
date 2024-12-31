using libraryTask_dexef.Application.Common.Interfaces;
using System.Security.Claims;

namespace libraryTask_dexef.Application.Services
{

    public class CurrentUser(ITokenService tokenService, ICookieService cookieService) : ICurrentUser
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly ICookieService _cookieService = cookieService;

        public int GetCurrentUserId()
        {
            var jwtCookie = _cookieService.Get();
            var token = _tokenService.ValidateToken(jwtCookie);
            var userId = token.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            return int.Parse(userId);
        }

        public string GetCurrentStringUserId()
        {
            var jwtCookie = _cookieService.Get();
            var token = _tokenService.ValidateToken(jwtCookie);
            var userId = token.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            return userId.ToString();
        }
    }
}