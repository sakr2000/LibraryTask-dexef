using LibraryTask_dexef.Shared.Enums;

namespace LibraryTask_dexef.Shared.Models.User
{

    public class UserProfileResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}