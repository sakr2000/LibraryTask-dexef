using LibraryTask_dexef.Application.Common.Interfaces;
using LibraryTask_dexef.Shared.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryTask_dexef.WebApi.Controllers
{
    public class AuthController(IAuthService authService) : BaseController
    {
        private readonly IAuthService _userService = authService;

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(UserSignInRequest request)
            => Ok(await _userService.SignIn(request));

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(UserSignUpRequest request, CancellationToken token)
            => Ok(await _userService.SignUp(request, token));

        [HttpDelete("logout")]
        public IActionResult Logout()
        {
            _userService.Logout();
            return Ok();
        }

        [HttpGet("refresh")]
        public async Task<IActionResult> RefreshToken()
            => Ok(await _userService.RefreshToken());

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
            => Ok(await _userService.GetProfile());
    }
}