using LibraryTask_dexef.Application.Common.Interfaces;
using LibraryTask_dexef.Shared.Models.AuthIdentity.UsersIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryTask_dexef.WebApi.Controllers
{
    public class AuthIdentityController : BaseController
    {
        private readonly IAuthIdentityService _authIdentityService;

        public AuthIdentityController(IAuthIdentityService authIdentityService)
        {
            _authIdentityService = authIdentityService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await _authIdentityService.Authenticate(request, cancellationToken);

            SetTokenInCookie(result.Token);
            return Ok(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            await _authIdentityService.Register(request, cancellationToken);
            return NoContent();
        }

        [HttpDelete("logout")]
        public async Task<IActionResult> Logout()
        {

            await _authIdentityService.LogOut();
            Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            RemoveTokenInCookie();
            return NoContent();
        }

        [HttpGet("refreshToken")]
        [Authorize]
        public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken)
        {
            var refreshToken = GetTokenInCookie();

            var response = await _authIdentityService.RefreshTokenAsync(refreshToken, cancellationToken);

            return Ok(response);
        }

        [HttpGet("profile")]
        [Authorize]
        [Authorize(Policy = "user_read")]
        [Authorize(Policy = "user_write")]
        public async Task<IActionResult> Profile(CancellationToken cancellationToken)
            => Ok(await _authIdentityService.Get(cancellationToken));

        private string GetTokenInCookie() => Request.Cookies["token_key"];

        private void SetTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10),
            };
            Response.Cookies.Append("token_key", refreshToken, cookieOptions);
        }

        private void RemoveTokenInCookie()
        {
            Response.Cookies.Delete("token_key");
        }
    }
}