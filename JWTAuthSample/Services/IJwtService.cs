using JWTAuthSample.Models;

namespace JWTAuthSample.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
