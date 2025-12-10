using Domain.Users.Enums;

namespace Domain.Users
{
    public class User
    {
        public long UserId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
