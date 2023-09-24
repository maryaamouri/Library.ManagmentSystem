namespace Libro.Application.Identity.Services.Login
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
