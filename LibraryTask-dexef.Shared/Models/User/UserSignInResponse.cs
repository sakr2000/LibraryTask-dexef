using LibraryTask_dexef.Shared.Enums;

namespace LibraryTask_dexef.Shared.Models.User
{

    public class UserSignInResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role Role { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}