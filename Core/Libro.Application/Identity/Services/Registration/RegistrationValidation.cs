using FluentValidation;

namespace Libro.Application.Identity.Services.Registration
{
    public class RegistrationRequestValidator : AbstractValidator<RegisrationRequest>
    {
        public RegistrationRequestValidator()
        {
            RuleFor(request => request.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 characters.");

            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(50).WithMessage("Email cannot exceed 50 characters."); ;

            RuleFor(request => request.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(request => request.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(request => request.Password)
              .NotEmpty().WithMessage("Password is required.")
              .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
              .Matches(@"^(?=.*[a-z])").WithMessage("Password must contain at least one lowercase letter (a-z).")
              .Matches(@"^(?=.*[A-Z])").WithMessage("Password must contain at least one uppercase letter (A-Z).")
              .Matches(@"^(?=.*\d)").WithMessage("Password must contain at least one digit (0-9).");
        }
    }
}
