
using libraryTask_dexef.Domain.Entities;
using libraryTask_dexef.Infrastructure.Interface;
using LibraryTask_dexef.Infrastructure.Data;

namespace libraryTask_dexef.Application.Repositories
{

    public class RefreshTokenRepository(LibraryDBContext context) : GenericRepository<RefreshToken>(context), IRefreshTokenRepository { }
}