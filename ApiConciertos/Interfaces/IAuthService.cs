using Microsoft.AspNetCore.Identity;

namespace ApiConciertos.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(string email, string password, string role);
        Task<String?> Login (string email, string password);
    }
}
