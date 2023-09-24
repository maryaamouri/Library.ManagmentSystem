using FluentValidation;
using Libro.Application.Identity.Services.Login;
using Libro.Application.Identity.Settings;
using Libro.Domain.UserProfiles;
using Libro.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Libro.Identity.Services
{
    internal class LoginService : ILoginService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserProfileRepository _profileRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly IValidator<LoginRequest> _validator;

        public LoginService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            IUserProfileRepository profileRepository,
            IOptions<JwtSettings> jwtSettings,
            IValidator<LoginRequest> validator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _profileRepository = profileRepository;
            _jwtSettings = jwtSettings.Value;
            _validator = validator;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var validationFailures = validationResult.Errors
                    .Select(error =>
                    {
                        return new FluentValidation.Results.ValidationFailure(error.PropertyName, error.ErrorMessage);
                    })
                    .ToList();

                throw new ValidationException("Login request validation failed.", validationFailures);
            }
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new LoginResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("UserId", user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
