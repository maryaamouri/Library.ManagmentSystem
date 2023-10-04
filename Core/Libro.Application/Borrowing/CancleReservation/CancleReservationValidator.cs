using FluentValidation;

namespace Libro.Application.Borrowing.CancleReservation
{
    public class CancleReservationValidator : AbstractValidator<CancleResarvationCommand>
    {
        public CancleReservationValidator()
        {
            RuleFor(crc => crc.TrasactionId)
                .NotEmpty().WithMessage("TransactionId Is Required.");
        }
    }
}
