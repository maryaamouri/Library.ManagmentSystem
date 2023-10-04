using FluentValidation;

namespace Libro.Application.Borrowing.ConfirmReceipt
{
    public class ConfirmReceiptValidator : AbstractValidator<ConfirmReciptCommand>
    {
        public ConfirmReceiptValidator()
        {
            RuleFor(crc => crc.PatronId)
                .NotEmpty().WithMessage("Patron is required.");

            RuleFor(crc => crc.TransationId)
                .NotEmpty().WithMessage("Book Transaction is required.");
        }
    }
}
