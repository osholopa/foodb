using FoodbWebAPI.Models;

namespace FoodbWebAPI.Auth
{
    public interface IJwtAuthenticationManager
    {
        public string GenerateToken(User user);

        public int? ValidateToken(string token);
    }
}