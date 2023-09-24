using FluentValidation;
using Libro.Application.Identity.Services.Login;

namespace Libro.Application.Identity.Services.Login
{
    public class LoginValidation : AbstractValidator<LoginRequest>
    {
        public LoginValidation()
        {
            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .Matches(@"^(?=.*[a-z])").WithMessage("Password must contain at least one lowercase letter (a-z).")
                .Matches(@"^(?=.*[A-Z])").WithMessage("Password must contain at least one uppercase letter (A-Z).")
                .Matches(@"^(?=.*\d)").WithMessage("Password must contain at least one digit (0-9).");
        }
    }
}
