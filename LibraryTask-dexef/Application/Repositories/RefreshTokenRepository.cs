
using LibraryTask_dexef.Domain.Entities;
using LibraryTask_dexef.Infrastructure.Interface;
using LibraryTask_dexef.Infrastructure.Data;

namespace LibraryTask_dexef.Application.Repositories
{

    public class RefreshTokenRepository(LibraryDBContext context) : GenericRepository<RefreshToken>(context), IRefreshTokenRepository { }
}