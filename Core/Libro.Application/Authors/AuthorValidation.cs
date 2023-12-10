using FluentValidation;

namespace Libro.Application.Authors
{
    public class AuthorRequestValidator : AbstractValidator<AuthorRequest>
    {
        public AuthorRequestValidator()
        {
            RuleFor(request => request.AuthorName)
                .NotNull().WithMessage("Author name must not be null.")
                .NotEmpty().WithMessage("Author name is required.")
                .MaximumLength(50).WithMessage("Author name must not exceed 50 chars.")
                .Matches("^[a-zA-Z ]+$").WithMessage("Author name can only contain letters and spaces.");
        }
    }

}
