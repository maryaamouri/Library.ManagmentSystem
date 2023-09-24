namespace Libro.Application.Identity.Services.Registration
{
     public interface IRegistrationService
    {
        Task<RegistrationResponse> Register(RegisrationRequest request);
    }
}
