using LibraryTask_dexef.Infrastructure.Interface;
using LibraryTask_dexef.Infrastructure.Data;

namespace LibraryTask_dexef.Application.Repositories
{

    public class UserRepository(LibraryDBContext context) : GenericRepository<ApplicationUser>(context), IUserRepository { }
}