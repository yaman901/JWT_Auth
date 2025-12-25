using JWTAuthSample.Models;

namespace JWTAuthSample.Repository
{
    public static class FakeUserRepository
    {
        public static List<User> Users = new()
    {
        new User
        {
            Id = 1,
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            Role = "Admin"
        }
    };

        public static User? GetByUsername(string username)
            => Users.FirstOrDefault(x => x.Username == username);
    }

}
