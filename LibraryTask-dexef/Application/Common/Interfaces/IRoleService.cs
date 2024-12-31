using LibraryTask_dexef.Shared.Models.AuthIdentity.Roles;

namespace libraryTask_dexef.Application.Common.Interfaces
{

    public interface IRoleService
    {
        Task<List<RoleViewModel>> GetAll();
    }
}