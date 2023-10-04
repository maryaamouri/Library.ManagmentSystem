using FluentValidation;
using Libro.Application.Borrowing.Reservation;

namespace Libro.Application.Borrowing.ReserveBook
{
    public class ReserveBookValidator : AbstractValidator<ReserveBookCommand>
    {
        public ReserveBookValidator()
        {
            RuleFor(rbc => rbc.BookId)
                .NotEmpty().WithMessage("Book Is Required.");
        }
    }
}
