
using LibraryTask_dexef.Shared.Models.AuthIdentity.UsersIdentity;

namespace LibraryTask_dexef.Application.Common.Interfaces
{

    public interface IUserService
    {
        Task<List<UserViewModel>> Get(CancellationToken cancellationToken);
        Task Update(UserUpdateRequest request, CancellationToken cancellationToken);
        Task Delete(string userId, CancellationToken cancellationToken);
        Task RoleAssign(RoleAssignRequest request, CancellationToken cancellationToken);
    }
}