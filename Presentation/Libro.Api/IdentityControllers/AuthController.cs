using Libro.Application.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libro.Application.Identity.Services.Login;
using Libro.Application.Identity.Services.Registration;

namespace Libro.Api.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _login;
        private readonly IRegistrationService _registration;

        public AuthController(ILoginService login, IRegistrationService registration)
        {
            _login = login;
            _registration = registration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            return Ok(await _login.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisrationRequest request)
        {
            return Ok(await _registration.Register(request));
        }
    }
}
