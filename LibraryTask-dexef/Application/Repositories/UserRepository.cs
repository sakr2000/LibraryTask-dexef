using libraryTask_dexef.Infrastructure.Interface;
using LibraryTask_dexef.Infrastructure.Data;

namespace libraryTask_dexef.Application.Repositories
{

    public class UserRepository(LibraryDBContext context) : GenericRepository<ApplicationUser>(context), IUserRepository { }
}