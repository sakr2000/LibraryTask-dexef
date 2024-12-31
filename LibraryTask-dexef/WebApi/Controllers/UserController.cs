using LibraryTask_dexef.Application.Common.Interfaces;
using LibraryTask_dexef.Shared.Models.AuthIdentity.UsersIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryTask_dexef.WebApi.Controllers
{

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserViewModel>>> Get(CancellationToken cancellationToken)
        {
            var users = await _userService.Get(cancellationToken);
            return Ok(users);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest request, CancellationToken cancellationToken)
        {
            await _userService.Update(request, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        [Authorize]
        public async Task<IActionResult> Delete(string userId, CancellationToken cancellationToken)
        {
            await _userService.Delete(userId, cancellationToken);
            return NoContent();
        }

        [HttpPost("assign-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RoleAssign([FromBody] RoleAssignRequest request, CancellationToken cancellationToken)
        {
            await _userService.RoleAssign(request, cancellationToken);
            return NoContent();
        }
    }
}