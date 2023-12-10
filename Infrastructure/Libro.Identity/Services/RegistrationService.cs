using FluentValidation;
using FluentValidation.Results;
using Libro.Application.Identity.Services.Registration;
using Libro.Domain.UserProfiles;
using Libro.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Libro.Identity.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserProfileRepository _profileRepository;
        private readonly IValidator<RegisrationRequest> _regisrationRequestValidator;

        public RegistrationService(UserManager<ApplicationUser> userManager,
            IUserProfileRepository profileRepository, 
            IValidator<RegisrationRequest> regisrationRequestValidator)
        {
            _userManager = userManager;
            _profileRepository = profileRepository;
            _regisrationRequestValidator = regisrationRequestValidator;
        }

        public async Task<RegistrationResponse> Register(RegisrationRequest request)
        {
            var validationResult = _regisrationRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                var validationFailures = validationResult.Errors
                    .Select(error => new ValidationFailure(error.PropertyName, error.ErrorMessage))
                    .ToList();

                throw new ValidationException("Registration request validation failed.", validationFailures);
            }
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Patron");

 
                    await _profileRepository.CreateAsync(new UserProfile(user.Id));

                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"Fild to Create User {result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email} already exists.");
            }
        }

        
    }
}
