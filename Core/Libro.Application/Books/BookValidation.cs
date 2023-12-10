using FluentValidation;

namespace Libro.Application.Books
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        public BookRequestValidator()
        {
            RuleFor(request => request.Title)
                .NotNull().WithMessage("Book Title must not be null.")
                .NotEmpty().WithMessage("Book Title  is required.")
                .MaximumLength(50).WithMessage("Book Title  must not exceed 50 chars.")
                .Matches("^[a-zA-Z0-9 ',.&]+$").WithMessage("Book Title can only contain letters, numbers, spaces, and common special characters.");

            RuleFor(request => request.Description)
                .MaximumLength(1000).WithMessage("Book Description  must not exceed 1000 chars.")
                 .Matches("^[a-zA-Z0-9 ',.&]+$").WithMessage("Book Description can only contain letters, numbers, spaces, and common special characters.");

            RuleFor(request => request.Genre)
                .MaximumLength(50).WithMessage("Book Gener  must not exceed 50 chars.")
                .Matches("^[a-zA-Z0-9 ',.&]+$").WithMessage("Book Genre can only contain letters, numbers, spaces, and common special characters.");

            RuleFor(request => request.PublicationDate)
                .Must(BeAValidDate).WithMessage("Invalid Publication Date.");
        }
        private bool BeAValidDate(DateTime? date)
        {
            return date.HasValue && date <= DateTime.UtcNow;
        }
    }
}