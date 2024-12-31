using libraryTask_dexef.Application.Common.Interfaces;
using LibraryTask_dexef.Shared.Models.AuthIdentity.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace libraryTask_dexef.Application.Services
{

    public class RoleService : IRoleService
    {
        private readonly RoleManager<RoleIdentity> _roleManager;

        public RoleService(RoleManager<RoleIdentity> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleViewModel>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return roles;
        }
    }
}
