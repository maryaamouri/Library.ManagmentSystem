using Libro.Application.Identity.Models;

namespace Libro.Application.Identity
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegistrationResponse> Register(RegisrationRequest request);
    }
}
